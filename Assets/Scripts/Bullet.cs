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
}
