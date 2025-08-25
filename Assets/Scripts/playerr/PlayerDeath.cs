using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public PlayerMove thePlayer;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("touched the ground");
        if (other.gameObject.name == "Plane")
        {
            Debug.Log("death plane hit");
            thePlayer.Death();
        }
    }
}
