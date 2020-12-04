using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRockMenu : MonoBehaviour
{

    public float rockSpeed = .6f;
    public float rockDegrees = 5f;

    private Vector3 startRotation;
    private float randomiser;


    void Start()
    {
        randomiser = Random.Range(0.0f, 1.0f);
    }

    void FixedUpdate()
    {
        //Vector3 newRotation = startRotation + new Vector3(, 90, -90);
        //this.transform.rotation = newRotation;

        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.x = 220;
        rotationVector.y = 20 + rockDegrees * (Mathf.Sin(rockSpeed * (randomiser + Time.time)));
        rotationVector.z = 171;
        transform.rotation = Quaternion.Euler(rotationVector);
    }
}