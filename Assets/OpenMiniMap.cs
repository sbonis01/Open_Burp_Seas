using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMiniMap : MonoBehaviour
{
    public GameObject img;
    public bool isImgOn;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        img.SetActive(false);
        isImgOn = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
   void OnTriggerStay(Collider other)
    {
        Debug.Log("collided and here");
        if(other.gameObject.tag == "Player")
        {
            img.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            img.SetActive(false);
        }
    }
}
