using UnityEngine;
using System.Collections;


public class EnterShip : MonoBehaviour
{
    public GameObject CarCam;
    private bool inVehicle = false;
    public DriveShip vehicleScript;
    public GameObject player;
    public GameObject text;
    public GameObject text2;
    public Transform Ship;
    private bool sinkn = false;
    public GameObject img;
    public GameObject img2;

    void Start()
    {
        //Debug.Log("entercannon-script started");
        vehicleScript = GetComponent<DriveShip>();
        player = GameObject.FindWithTag("Player");
        img.SetActive(false);
        img2.SetActive(false);
        text.SetActive(false);
        text2.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            text.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                text.SetActive(false);
                text2.SetActive(true);
                img.SetActive(true);
                img2.SetActive(true);
                Ship.GetComponent<MeshCollider>().convex = true;
                //Debug.Log("E has been pressed");
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
            img.SetActive(false);
            img2.SetActive(false);
            text.SetActive(false);
            //Debug.Log("exitting");
        }
    }

    public void sinking()
    {
        sinkn = true;
    }

    void Update()
    {
        if(sinkn)
        {
            text2.SetActive(false);
            return;
        }
        if (inVehicle == true && Input.GetKeyDown(KeyCode.R))
        {
            text2.SetActive(false);
            Ship.GetComponent<MeshCollider>().convex = false;
            CarCam.SetActive(false);
            vehicleScript.enabled = false;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
        }
    }
}