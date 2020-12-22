using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrown : MonoBehaviour
{

    public PlayerHealth health;
    public PlayerMovement player;


    void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.name == "WaterLine")
         {
            player.drown = true;
            health.drown = true;
            Debug.Log("player and health now drowning");
         }
    }

}
