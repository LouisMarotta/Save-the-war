using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1f;

    private Vector2 shootDir;
    public void Setup(Vector2 shootDir)
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        moveSpeed = 1f;
        rigidbody2D.AddForce(shootDir * moveSpeed, ForceMode2D.Impulse);

        Debug.Log(shootDir);
        
    }
}
