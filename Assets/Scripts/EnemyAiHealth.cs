using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAiHealth : MonoBehaviour
{

    public int maxHealth = 10;
    public GameObject player;
    public int currentHealth;
    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }
    private void Update()
    {
        if(currentHealth == 0)
        {
            Destroy(player);
        }
    }

    void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("collision bullet");
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
