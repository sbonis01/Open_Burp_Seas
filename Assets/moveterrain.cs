using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveterrain : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = this.transform.position + new Vector3(0f,0f, speed);
    }
}
