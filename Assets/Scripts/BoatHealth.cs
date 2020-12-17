using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoatHealth : MonoBehaviour
{
    private bool functionCalled;
    public int maxHealth = 10;
    public GameObject player;
    public int currentHealth;
    public HealthBar healthbar;
    public TextMeshProUGUI shipsdestoryed;
    Animator m_animator;
    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        m_animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
        textsetter script = shipsdestoryed.GetComponent<textsetter>();

    }

    public void Update()
    {
        if(currentHealth < 0)
        {      
            if (!functionCalled)
            {
                counter++;
                //Debug.Log("Counter = " + counter + "setting counter in textsetter");
                shipsdestoryed.GetComponent<textsetter>().counter += counter;
                functionCalled = true;
            }
            //Debug.Log("running animation");
            m_animator.SetTrigger("sink");

            //Destroy(player);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collisions");
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Bullet")
        {
            //Debug.Log("collision bullet");
            TakeDamage(2);
        }
        if(other.gameObject.tag == "CannonBall")
        {
            //Debug.Log("cannon ball hit");
            TakeDamage(2);
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
    }

    void addHealth(int health){
        currentHealth += health;
        healthbar.setHealth(currentHealth);
    }
}
