using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public PlayerMove thePlayer;

    private void Update()
    {
        bool dead = (Physics.Raycast(thePlayer.gameObject.transform.position, Vector3.down, 1.5f, LayerMask.GetMask("DeathPlane")));
        if (dead)
        {
            Debug.Log("your mom");
            Death();
        }
    }

    public void Death()
    {
        this.gameObject.SetActive(false);
        Respawn();
    }

    public void Respawn()
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = thePlayer.spawnPoint;
    }
}
