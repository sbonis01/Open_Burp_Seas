using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{

    public GameObject obj1, obj2, obj3, obj4, obj5, obj6, obj7, obj8, text, black;
    private bool blink = true;
    private bool go = true;
    public bool dead = false;
    public float timer = 1;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        obj1.SetActive(false);
        obj2.SetActive(false);
        obj3.SetActive(false);
        obj4.SetActive(false);
        obj5.SetActive(false);
        obj6.SetActive(false);
        obj7.SetActive(false);
        obj8.SetActive(false);
        
        AudioListener.volume = 0f;

        if(dead == true)
        {
            StartMenu();
        }
    }

    public void StartMenu()
    {
        go = false;
        obj1.SetActive(true);
        obj2.SetActive(true);
        obj3.SetActive(true);
        obj4.SetActive(true);
        obj5.SetActive(true);
        obj6.SetActive(true);
        obj7.SetActive(true);
        obj8.SetActive(true);
        text.SetActive(false);
        black.SetActive(false);
        AudioListener.volume = 1f;
    }

    public void LoadScene()
    {
        //Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("TimTest");
    }
    public void Tutorial()
    {
        Debug.Log("Working");
    }
}
