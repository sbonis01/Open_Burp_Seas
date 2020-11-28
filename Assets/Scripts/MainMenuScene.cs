using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    //public GameObject pauseMenu;
    ////void Start()
    ////{
    ////    pauseMenu.SetActive(true);
    ////}

    // Start is called before the first frame update
    public void LoadScene()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("TimTest");
    }
    public void Tutorial()
    {
        Debug.Log("Working");
    }
}
