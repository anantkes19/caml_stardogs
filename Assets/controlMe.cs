using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class controlMe : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public GameObject misslePrefab;
    public GameObject ship2;

    private GameObject sounds;
    private GameObject background;
    private GameObject blow;

    private Rigidbody rb;

    // Start is called before the first frame update
    void FireSound()
    {
        var audioData = sounds.GetComponent<AudioSource>();
        audioData.Play(0);
    }

    void backgroundSound()
    {
        var audioData1 = background.GetComponent<AudioSource>();
        audioData1.Play(0);
    }
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireSound();
            CmdFire();
        }

        Debug.Log(rb.velocity);

        float bias = 0.96f;



        Vector3 moveCamTo = transform.position - transform.forward * 15f + Vector3.up * 5f;
        Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1.0f - bias);
        Camera.main.transform.LookAt(transform.position + transform.forward * 30f);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(200f * transform.forward * Time.deltaTime);
        }
        else
        {
            rb.AddForce(-rb.velocity.normalized * Time.deltaTime * 150f);
        }
        Debug.Log(Input.GetAxis("Horizontal"));

        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        {
            
            transform.Rotate(2f * Input.GetAxis("Vertical"), 0.0f, -2f * Input.GetAxis("Horizontal"));
        }
    }

    public override void OnStartLocalPlayer()
    {
        //GetComponent<MeshRenderer>().material.color = Color.red;
        Camera.main.transform.parent = this.transform;
        Camera.main.transform.localPosition = new Vector3(0f, 5, -20f);
        rb = GetComponent<Rigidbody>();
        sounds = GameObject.Find("Sounds");
        background = GameObject.Find("BackgroundSounds");

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

    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject.transform.root;
        var hitPlayer = hit.GetComponent<controlMe>();
        if (hitPlayer != null)
        {
            var combat = hit.GetComponent<Combat>();
            combat.TakeDamage(10);

            Destroy(gameObject);
        }
    }
}
