using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkShip : MonoBehaviour
{
    public DriveShip vehicleScript;
    public SinkShipHelper ship;
    public EnterShip shipC;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Terrain")
        {
            vehicleScript.enabled = false;
            shipC.sinking();
            ship.sink();
        }
    }


}
