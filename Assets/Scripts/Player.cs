using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;

    public BoxCollider2D player;

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

    public void TakeDamage(int damage)
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

    /*void OnCollisionEnter(UnityEngine.Collision other)
    {
        Debug.Log(other.gameObject.name);
    }*/
}
