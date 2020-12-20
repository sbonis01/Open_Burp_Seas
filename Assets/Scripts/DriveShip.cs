using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveShip: MonoBehaviour
{
    public float turnSpeed = 500f;
    public float accelerateSpeed = 100f;

    public Transform Ship;
    public float speed = .001f;
    private float v, h;
    private float RotationY, velocity, rotationV;
    // Start is called before the first frame update
    private void Awake()
    {
       Ship = Ship.GetComponent<Transform>();
       RotationY = Ship.rotation.y;
       velocity = 0f;
       rotationV = 0f;
    }
  
    // Update is called once per frame
    void FixedUpdate()
    {
        var rotationVector = Ship.rotation.eulerAngles;
        rotationVector.y += rotationV;
        RotationY += rotationV;
        Ship.rotation = Quaternion.Euler(rotationVector);



        float shipZ = velocity * Mathf.Cos(RotationY * Mathf.Deg2Rad);
        float shipX = velocity * Mathf.Sin(RotationY * Mathf.Deg2Rad);
        Ship.transform.position -= new Vector3(shipX, 0, shipZ);

        //if (velocity >= 0f)
        //{
        //    velocity -= speed/50;
        //}

        if (rotationV > 0f)
        {
            rotationV -= .001f;
        }

        if (rotationV < 0f)
        {
            rotationV += .001f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            //float shipZ = Mathf.Cos(RotationY* Mathf.Deg2Rad);
            //float shipX = Mathf.Sin(RotationY* Mathf.Deg2Rad);
            //Ship.transform.position -= new Vector3(shipX, 0, shipZ);
            if (velocity < .2f)
            {
                velocity += speed / 10f;
            }
            else if (velocity < .7f)
            {
                velocity += speed/3f;
            }

            //Ship.transform.position -= new Vector3(Input.GetAxis("Horizontal") * 3, 0, Input.GetAxis("Vertical") * 2);
            //Ship.transform.position -= new Vector3(Input.GetAxis("Horizontal") * 3, 0, Input.GetAxis("Vertical") * 2);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (velocity >= 0f)
            {
                velocity -= speed/30f;
            }
            //Ship.transform.position += new Vector3(-Input.GetAxis("Horizontal") * 3, 0, -Input.GetAxis("Vertical") * 2);
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (rotationV > 0f)
            {
                rotationV -= .02f;
            }
            if (rotationV > -.5f)
            {
                rotationV -= .01f;
            }
            //var rotationVector = Ship.rotation.eulerAngles;
            //rotationVector.y -= .2f;
            //RotationY -= .2f;
            //Ship.rotation = Quaternion.Euler(rotationVector);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (rotationV < 0f)
            {
                rotationV += .02f;
            }
            if (rotationV < .5f)
            {
                rotationV += .01f;
            }
            //var rotationVector = Ship.rotation.eulerAngles;
            //rotationVector.y += .2f;
            //RotationY += .2f;
            //Ship.rotation = Quaternion.Euler(rotationVector);
        }

    }
}
