using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        //Intitialize currenthealth with max health value
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {   /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
        */
    }

    void TakeDamage(int damage)
    {
        Debug.Log($"Took {damage} damage");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void Heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }

    bool isDead()
    {
        return currentHealth == 0;
    }
}
