using UnityEngine;
using System.Collections;

public class RotatePlayer : MonoBehaviour {

    private Rigidbody rb;
    public float rotateSpeed;

    Vector3 rotationLeft;
    Vector3 rotationRight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    void FixedUpdate ()
    {

        rotationLeft.Set(0f, -rotateSpeed, 0f);
        rotationRight.Set(0f, rotateSpeed, 0f);

        rotationLeft = -rotationLeft.normalized * -rotateSpeed;
        rotationRight = -rotationRight.normalized * rotateSpeed;

        Quaternion deltaRotationLeft = Quaternion.Euler (rotationLeft * Time.fixedDeltaTime);
        Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.Q))
        {
            rb.MoveRotation(rb.rotation * deltaRotationLeft);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rb.MoveRotation(rb.rotation * deltaRotationRight);
        }

    }
}
