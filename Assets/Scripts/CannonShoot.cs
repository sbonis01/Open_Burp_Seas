using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour

{
    public GameObject cannon;
    public Camera playerCamera;
    public GameObject bulletPrefab;
    public bool finished;
    // Start is called before the first frame update
    void Start()
    {
        finished = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && finished == true)
        {

          
            StartCoroutine(ExampleCoroutine());
        }
     
    }


    IEnumerator ExampleCoroutine()
    {
        finished = false;
        GameObject bulletObject = Instantiate(bulletPrefab);
        bulletObject.transform.position = cannon.transform.position + playerCamera.transform.forward;
        //bulletObject.transform.up = playerCamera.transform.up;
        bulletObject.transform.forward = playerCamera.transform.forward;
        yield return new WaitForSeconds(1);
        finished = true;
        //yield on a new YieldInstruction that waits for 5 seconds.


    }
}
