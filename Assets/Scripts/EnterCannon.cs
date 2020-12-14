using UnityEngine;
using System.Collections;


public class EnterCannon : MonoBehaviour
{
    public GameObject CarCam;
    private bool inVehicle = false;
    public Vehicle vehicleScript;
    public GameObject player;

    void Start()
    {
        Debug.Log("entercannon-script started");
        vehicleScript = GetComponent<Vehicle>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {

            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("E has been pressed");
                CarCam.SetActive(true);
                player.transform.parent = gameObject.transform;
                vehicleScript.enabled = true;
                player.SetActive(false);
                inVehicle = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("exitting");
        }
    }
    void Update()
    { 
        if (inVehicle == true && Input.GetKeyDown(KeyCode.R))
        {
            CarCam.SetActive(false);
            vehicleScript.enabled = false;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
        }
    }
}