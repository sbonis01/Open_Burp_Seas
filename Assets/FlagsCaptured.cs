using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlagsCaptured : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textMeshPro;
    public GameObject flag;
    int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = x.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colliding");
        if(collision.gameObject.tag == "Player")
        {
            x++;
            Destroy(flag);
        }
    }
}
