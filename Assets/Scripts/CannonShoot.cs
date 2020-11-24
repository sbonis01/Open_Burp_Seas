using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour

{
    public GameObject cannon;
    public Camera playerCamera;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = cannon.transform.position + playerCamera.transform.forward;
            //bulletObject.transform.up = playerCamera.transform.up;
            bulletObject.transform.forward = playerCamera.transform.forward;
        }
    }
}
