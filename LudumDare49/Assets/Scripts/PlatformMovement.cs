using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Vector3 cursor;
    public float platformSpeed;
    public float maxPlatformSpeed;
    public Rigidbody2D rb;

    private Vector3 velocity = Vector3.zero;

    private Vector3 rotation = Vector3.forward;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        CursorFollow();

        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Rotate(-rotation * rotationSpeed * Time.deltaTime);
        }
    }


    private void CursorFollow()
    {
        cursor = GetMouseWorldPosition();
        transform.position = Vector3.SmoothDamp(transform.position, cursor, ref velocity, platformSpeed * Time.deltaTime, maxPlatformSpeed);

    }

    public Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }


    public Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
