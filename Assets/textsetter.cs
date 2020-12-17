using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textsetter : MonoBehaviour
{
    public int counter;
    [SerializeField] 
    public TextMeshProUGUI shipswrecked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("counter in textsetter is" + counter);
        shipswrecked.text = counter.ToString();
    }
}
