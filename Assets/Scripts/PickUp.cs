using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDest;
    public GameObject player;
    private void Update()
    {
        if (player.activeInHierarchy == true)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            RaycastHit hit;
            if (Input.GetKey(KeyCode.Mouse1))
            {

                if (Physics.Raycast(ray, out hit))
                {
                    var selection = hit.transform;
                    var selectionRender = selection.GetComponent<Renderer>();
                    if (selectionRender != null && selectionRender.tag == "Barrell")
                    {
                        selection.GetComponent<MeshCollider>().enabled = false;
                        selection.GetComponent<Rigidbody>().useGravity = false;
                        selection.transform.position = theDest.position;
                        selection.transform.parent = GameObject.Find("Destination").transform;
                    }
                }
            }

            this.transform.parent = null;
            this.GetComponent<Rigidbody>().useGravity = true;
            //this.GetComponent<MeshCollider>().enabled = true;


        }
    }

}