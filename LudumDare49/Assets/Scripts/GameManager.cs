using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gun;
    public GameObject target;

    public GameObject platform;
    public GameObject monster;

    private Vector3 targetPosition;

    public Vector3 left = new Vector3(-12.5f, 0, 0);
    public Vector3 bottom = new Vector3(0, -7, 0);
    public Vector3 right = new Vector3(12.5f, 0, 0);

    private int isLost = 1; // 0 - true, everything else - false

    public WaitForSeconds waitBeforeGunSpawning;
    public WaitForSeconds waitBeforeMultipleGunSpawning;

    public float time;

    private void Awake()
    {
        left = new Vector3(-12.5f, 0, 0);
        bottom = new Vector3(0, -7, 0);
        right = new Vector3(12.5f, 0, 0);

        waitBeforeGunSpawning = new WaitForSeconds(2);
        waitBeforeMultipleGunSpawning = new WaitForSeconds(0.5f);


        targetPosition = target.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
        StartCoroutine(SpawnGun());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void GenerateGun()
    {
        GameObject gunInstance;

        int side = Random.Range(1, 6);
        switch (side)
        {
            case 1:
                {
                    gunInstance = Instantiate(gun, (left + new Vector3(0, Random.Range(-5, 0f))), Quaternion.identity);
                    Debug.Log("Left");
                    break;
                }
            case 2:
                {
                    gunInstance = Instantiate(gun, (bottom + new Vector3(Random.Range(-10, 10f), 0, 0)), Quaternion.identity);
                    Debug.Log("Bottom");
                    break;
                }
            case 3:
                {
                    gunInstance = Instantiate(gun, (right + new Vector3(0, Random.Range(-5, 0f), 0)), Quaternion.identity);
                    Debug.Log("Right");
                    break;
                }
            default:
                {
                    gunInstance = Instantiate(gun, (bottom + new Vector3(Random.Range(-10, 10f), 0, 0)), Quaternion.identity);
                    Debug.Log("Default");
                    break;
                }
        }

        Vector3 aimDirection = (targetPosition - gunInstance.transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        gunInstance.transform.eulerAngles = new Vector3(0, 0, angle - 90);

        gunInstance.GetComponent<GunShooter>().angle = angle;

    }

    public void Lose()
    {
        Debug.Log("You lost!");
        isLost = 0;
        platform.GetComponent<PlatformMovement>().ThrowAwayPlatform();
    }

    IEnumerator SpawnGun()
    {
        yield return new WaitForSeconds(5);


        while (isLost == 1)
        {
            for (int i = 0; i <= time / 20; i++)
            {
                if (isLost != 1)
                    break;

                if(i >= 45)
                { 
                    if (isLost != 1)
                        break;

                    GenerateGun();
                    yield return new WaitForSeconds(0.1f);
                }


                GenerateGun();
                yield return waitBeforeMultipleGunSpawning;
            }
            yield return waitBeforeGunSpawning;
        }
    }

    IEnumerator Timer()
    {
        while (isLost == 1)
        {
            yield return new WaitForSecondsRealtime(1);

            time += 1;
        }
    }




}
