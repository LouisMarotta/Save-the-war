using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // https://www.youtube.com/watch?v=qN9UzT_HXEw

    // https://www.youtube.com/watch?v=4ivFemmpYus

    // https://drive.google.com/drive/folders/0B8Zl1dvvnT64Ry03YnJxV2s3TVE



    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject gunPoint;


    public float fireRate = 5f;
    public float range = 60f; // weapon range

    public LayerMask whatToHit;     // l'oggetto che il raycast deve colpire 

    float timeFire = 0;

    Vector2 PlayerPosition;
    Vector2 GunPoint;

    bool colpito = false;

    // Start is called before the first frame update
    void Start()
    {
        colpito = false;
    }

    // Update is called once per frame
    void Update()
    {
        colpito = false;


        // Mettere questo forse nel void Start?!!?!?!?? -----------------------
        PlayerPosition = player.transform.position;  // Prendo la posizione del Player 
        GunPoint = gunPoint.transform.position;  // Prendo la posizione da dove la pallottola dovra' uscire

        colpito = ShootRay(GunPoint, PlayerPosition);  // se il ray trova e colpisce il player allora true

        if (colpito)
            OnShoot();
            
    }

    public void OnShoot()
    {
        if (fireRate == 0)
        {
            // Single fire mode
            Shoot();
        } else
        {
            if (Time.time > timeFire)
            {
                timeFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    bool ShootRay(Vector2 origin, Vector2 destination)
    {
        colpito = false;

        RaycastHit2D hit = Physics2D.Raycast(origin, destination - origin, range, whatToHit);     // attenzione a fare sempre direction - origin per calcolare la direzione

        if (hit.collider != null)
        {
            colpito = true;
        }

        Debug.DrawRay(origin, destination - origin, Color.blue, 0.1f);
        Debug.DrawLine(origin, new Vector2(origin.x + range, origin.y), Color.red, 0.1f);  // range del colider

        return colpito;
    }



    void Shoot()
    {
        var bulletObject = Instantiate(bullet, GunPoint, Quaternion.identity);
        bulletObject.GetComponent<BulletPhysics>().Setup((PlayerPosition - GunPoint));
    }

    void RotateGun()
    {

    }

    public static float GetAngleFromVectorFloat(Vector2 dir)    // calcola l'angolo data la direzione (serve per ruotare il bullet verso il player)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

}
