using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMotion : MonoBehaviour
{
    public Rigidbody rb;

    // public Vector3 force = (0f,0f,0f);

    private float increment = 0;

    private float speed = 0f;

    private float rotationCoefficient = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // rb.useGravity = false;

        rb = GetComponent<Rigidbody>();

        
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveCamTo = transform.position - transform.forward*10f +
                            Vector3.up*2f;
        Camera.main.transform.position = moveCamTo;
        Camera.main.transform.LookAt( transform.position);

        if (Input.GetKey(KeyCode.LeftShift)){
            speed += 50;
        } else {
            speed -= 10;
        }

        if (speed < 0) {
            speed = 0;
        }

        rb.AddForce(speed * transform.forward * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.LeftShift)){
        
            increment -= 4f;
        
        }

        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D)){
            transform.Rotate(2f*Input.GetAxis("Vertical"), 0.0f, -2f*Input.GetAxis("Horizontal"));
        }


    }
}
