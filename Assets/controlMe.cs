using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class controlMe : NetworkBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.down * 5);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up * 5);

        var z = Input.GetAxis("Vertical") * 0.1f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }

        transform.Translate(0, 0, z);
    }

    public override void OnStartLocalPlayer()
    {
        //GetComponent<MeshRenderer>().material.color = Color.red;
        Camera.main.transform.parent = this.transform;
        Camera.main.transform.localPosition = new Vector3(0f, 5, -15f);
    }

    [Command]
    void CmdFire()
    {
        // create the bullet object from the bullet prefab
        var bullet = (GameObject)Instantiate( bulletPrefab, transform.position + transform.forward * 6f, transform.rotation);

        // make the bullet move away in front of the player
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * 50;

        NetworkServer.Spawn(bullet);

        // make bullet disappear after 2 seconds
        Destroy(bullet, 5.0f);
    }
}
