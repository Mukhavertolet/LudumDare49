using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        left = new Vector3(-12.5f, 0, 0);
        bottom = new Vector3(0, -7, 0);
        right = new Vector3(12.5f, 0, 0);

        targetPosition = target.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateGun();
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

}
