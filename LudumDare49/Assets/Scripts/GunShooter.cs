using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter : MonoBehaviour
{
    public GameObject projectile;
    public GameObject firePoint;

    [HideInInspector] public float angle;
    public float projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootAndDestroy());
    }

    IEnumerator ShootAndDestroy()
    {
        yield return new WaitForSeconds(0.65f);

        GameObject bulletInstance = Instantiate(projectile, firePoint.transform.position, Quaternion.identity);
        LaunchBullet(bulletInstance.GetComponent<Rigidbody2D>(), angle, projectileSpeed);

        yield return new WaitForSeconds(1);

        Destroy(gameObject);

    }

    void LaunchBullet(Rigidbody2D rb, float angle, float projectileSpeed)
    {
        rb.AddForce(firePoint.transform.up * projectileSpeed, ForceMode2D.Impulse);
    }
}
