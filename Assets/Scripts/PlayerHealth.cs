using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 30;
    public int currentHealth;
    public bool drown;

    public CharacterController player;

    public HealthBar healthbar;

    private float timeRemaining = .1f;

    // Start is called before the first frame update
    void Start()
    {
        drown = false;
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        //print(other.tag);
        //if (other.tag == "Bullet")
        //{
            //TakeDamage(2);
        //}
    }

    public void FixedUpdate()
    {
        if (drown)
        {
            //player.enabled = false;
            //transform.position = transform.position + new Vector3(0, -1, 0);
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log(currentHealth);
                TakeDamage(1);
                timeRemaining = .2f;
            }
        }   
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);

        if(currentHealth < 0)
        {
            SceneManager.LoadScene("PostDeath");
            return;
        }
    }

    

    void addHealth(int health){
        currentHealth += health;
        healthbar.setHealth(currentHealth);
    }

}
