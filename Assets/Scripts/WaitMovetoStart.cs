using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WaitMovetoStart : MonoBehaviour
{
    public MeshRenderer yup;
    public GameObject object1;
    public GameObject object2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        yup.enabled = false;
        object1.SetActive(false);
        object2.SetActive(false);
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    // Update is called once per frame

}
