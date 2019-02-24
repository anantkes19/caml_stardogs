//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class controller : MonoBehaviour {

//    private Vector3 pos;
//	// Use this for initialization
//	void Start () {
		
//	}
	
//	// Update is called once per frame
//	void Update () {
//        pos = transform.position;
//        if(pos.y < 0)
//        {
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//        }

//        if(Input.GetKey(KeyCode.A))
//        {
//            pos -= transform.right * 0.1f;
//        }
//        if (Input.GetKey(KeyCode.D))
//        {
//            pos += transform.right * 0.1f;
//        }
//        if (Input.GetKey(KeyCode.W))
//        {
//            pos += transform.forward * 0.1f;
//        }
//        if (Input.GetKey(KeyCode.S))
//        {
//            pos -= transform.forward * 0.1f;
//        }

//        transform.position = pos;


//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if(collision.transform.tag == "Finish")
//        {
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//        }
//    }
//}
