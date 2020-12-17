using UnityEngine;
using System.Collections;


public class EnterCannon : MonoBehaviour
{
    public GameObject CarCam;
    private bool inVehicle = false;
    public Vehicle vehicleScript;
    public GameObject player;
    public GameObject text1;
    public GameObject text2;

    void Start()
    {
        Debug.Log("entercannon-script started");
        vehicleScript = GetComponent<Vehicle>();
        player = GameObject.FindWithTag("Player");
        text1.SetActive(false);
        text2.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            text1.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                text1.SetActive(false);
                text2.SetActive(true);
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
            text1.SetActive(false);
            //Debug.Log("exitting");
        }
    }
    void Update()
    { 
        if (inVehicle == true && Input.GetKeyDown(KeyCode.R))
        {
            CarCam.SetActive(false);
            text2.SetActive(false);
            vehicleScript.enabled = false;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
        }
    }
}