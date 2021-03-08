using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        //Debug.Log("Cancellato");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            var myscript = collision.gameObject.GetComponent<Player>();
            myscript.TakeDamage(1);
        }

        if (collision.gameObject.tag == "Object")
        {
            gameObject.SetActive(false);
            Debug.Log("Collisione oggetto");
        }
    }
}
