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
        rigidbody2D.AddForce(shootDir * moveSpeed, ForceMode2D.Impulse);

        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootDir));
    }

    public static float GetAngleFromVectorFloat(Vector2 dir)    // calcola l'angolo data la direzione (serve per ruotare il bullet verso il player)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
}
