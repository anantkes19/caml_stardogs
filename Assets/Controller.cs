using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
    public class Controller : MonoBehaviour
    {
        public float speed = 10.0F;
        public float rotationSpeed = 100.0F;

        public Controller()
        {
        }

        void Update()
        {
            var translation = Input.GetAxis("Horizontal") * speed;
            var rotation = Input.GetAxis("Vertical") * rotationSpeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);

            if (Input.GetButton("Jump"))
            {
                this.GetComponent<Rigidbody>().AddForce(0, 10, 0);
                Debug.Log("JUMP pressed");
            }

            if (Input.GetButton("Fire1"))
            {
                //this.GetComponent<Rigidbody>().AddForce(0, 10, 0);
                Debug.Log("FIRE1 pressed");

            }

            if (Input.GetButton("Fire2"))
            {
                //this.GetComponent<Rigidbody>().AddForce(0, 10, 0);
                Debug.Log("FIRE2 pressed");

            }

            if (Input.GetButton("Fire3"))
            {
                //this.GetComponent<Rigidbody>().AddForce(0, 10, 0);
                Debug.Log("FIRE3 pressed");

            }

            float didAttack = Input.GetAxis("Attack");
            if (didAttack > 0.0)
            {
                Debug.Log("ATTACKING pressed");
            }

        }

    }
}
