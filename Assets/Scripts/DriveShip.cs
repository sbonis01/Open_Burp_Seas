using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveShip: MonoBehaviour
{
    public float turnSpeed = 500f;
    public float accelerateSpeed = 100f;

    public Transform Ship;
    private float v, h;
    // Start is called before the first frame update
    private void Awake()
    {

       Ship = Ship.GetComponent<Transform>();
       
    }
  
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            Ship.transform.position -= new Vector3(Input.GetAxis("Horizontal") * 3, 0, Input.GetAxis("Vertical") * 2);
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Ship.transform.position += new Vector3(-Input.GetAxis("Horizontal") * 3, 0, -Input.GetAxis("Vertical") * 2);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Ship.transform.localEulerAngles += new Vector3(0f, 1, 0f);
            Ship.position += new Vector3(-1, 0f, 0f);
            //Ship.transform.Rotate(transform.localEulerAngles.x, transform.localEulerAngles.y-turnSpeed, transform.localEulerAngles.z);
            //transform.localEulerAngles.y.set(transform.localEulerAngles.y - turnSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
           
            Ship.transform.localEulerAngles += new Vector3(0f, -1, 0f);
            Ship.position += new Vector3(1, 0f, 0f);
            //Ship.transform.Rotate(transform.localEulerAngles.x, transform.localEulerAngles.y+turnSpeed, transform.localEulerAngles.z);
        }

    }
}
