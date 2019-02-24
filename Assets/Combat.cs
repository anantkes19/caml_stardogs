using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Combat : NetworkBehaviour
{

    public const int maxHealth = 100;

    [SyncVar]
    public int health = maxHealth;
    private GameObject blow;

    public override void OnStartLocalPlayer()
    {
        blow = GameObject.Find("Explosion");
    }

        public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        health -= amount;
        if (health <= 0)
        {
            blow = GameObject.Find("Explosion");
            health = maxHealth;

            // called on the server, will be invoked on the clients
            RpcRespawn();
        }
    }

    [ClientRpc]
    public void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // move back to zero location
            transform.position = Vector3.zero;
        }
    }
}
