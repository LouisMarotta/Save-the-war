using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;

    public BoxCollider2D player;

    private GameMaster gm;

    void Start()
    {
        //Intitialize currenthealth with max health value
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
        
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
        //Debug.Log($"Took {damage} damage");
        currentHealth -= damage;
        if (IsDead())
        {
            //Die();
        }
        healthBar.SetHealth(currentHealth);
    }

    void Heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }

    bool IsDead()
    {
        return currentHealth <= 0;
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Destroy(gameObject);
    }
    /*void OnCollisionEnter(UnityEngine.Collision other)
    {
        Debug.Log(other.gameObject.name);
    }*/

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "DangerousObject") // se il Player tocca un oggetto con tag "DangerousObject", muore (usato per: tilemap)
        {
            Debug.Log("DIEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
            Die();
        }
    }
}
