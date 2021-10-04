using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsStretching : MonoBehaviour
{
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 aimDirection = (target.position - gameObject.transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        gameObject.transform.eulerAngles = new Vector3(0, 0, angle + 90);


        Vector3 scale = gameObject.transform.localScale;

        float size = Vector2.Distance(gameObject.transform.position, target.position);

        scale.Set(1.5f, size / 3.7f, 1);


        Debug.Log(size);

        gameObject.transform.localScale = scale;
    }
}
