using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : MonoBehaviour
{
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
