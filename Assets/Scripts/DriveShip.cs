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
    private void Update()
    {
        //float h = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        //float v = Input.GetAxis("Vertical") * accelerateSpeed * Time.deltaTime;
        //Debug.Log("Horizontal" + h);
        //Debug.Log("Vertical" + v);
        //Debug.Log(Ship.position);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Ship.position += new Vector3(0f, 0f, -1);
        }else if (Input.GetKey(KeyCode.S))
        {
            Ship.position += new Vector3(0f, 0f, 1);
        }else if (Input.GetKey(KeyCode.D))
        {
            Ship.position += new Vector3(1, 0f, 0f);
            Ship.transform.Rotate(Vector3.down * turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Ship.position += new Vector3(-1, 0f, 0f);
            Ship.transform.Rotate(-Vector3.down * turnSpeed * Time.deltaTime);
        }

    }
}
