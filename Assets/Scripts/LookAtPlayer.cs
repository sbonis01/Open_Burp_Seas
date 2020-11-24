using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    public Transform player;
    public GameObject Canvas;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }


    void Update()
    {
        Canvas.transform.LookAt(player);
    }
}
