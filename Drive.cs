//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace AssemblyCSharp
//{
//    public class Controller : MonoBehaviour
//    {
//        public float speed = 10.0F;
//        public float rotationSpeed = 100.0F;

//        public Controller()
//        {
//        }

//        void Update()
//        {
//            var translation = Input.GetAxis("Horizontal") * speed;
//            var rotation = Input.GetAxis("Vertical") * rotationSpeed;
//            translation *= Time.deltaTime;
//            rotation *= Time.deltaTime;

//            transform.Translate(0,0,translation);
//            transform.Rotate(0, rotation, 0);
//        }
//    }
//}
