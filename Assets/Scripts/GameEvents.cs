using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameEvents : MonoBehaviour
{
    public Slider slider;
    public int nextlvl;
    public TextMeshProUGUI scenemover;

    void Update()
           {
       
            if (slider.value == 0 && (nextlvl-2) > 0){
                    SceneManager.LoadScene("Scene" + (nextlvl-2).ToString());
            }else if(slider.value == 0 && (nextlvl - 2) == 0)
            {
                SceneManager.LoadScene("Scene1");
            }
            scenemover.text = (nextlvl - 1).ToString();
     }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Point")
        {
        
            SceneManager.LoadScene("Scene"+ nextlvl);

        }
    }
}
