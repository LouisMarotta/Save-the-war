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
    Vector2 Direction;  // direzione in cui sparare, PlayerPosition - GunPoint

    Transform gun;  // La pistola, children di Enemy
    public float rotationSpeed = 0.0f;  // gun rotation speed / time?

    bool colpito = false;

    void Start()
    {
        colpito = false;
        gun = transform.Find("Gun");
    }

    void Update()
    {
        colpito = false;

        PlayerPosition = player.transform.position;  // Prendo la posizione del Player 
        GunPoint = gunPoint.transform.position;  // Prendo la posizione da dove la pallottola dovra' uscire
        Direction = PlayerPosition - GunPoint;

        colpito = ShootRay(GunPoint, PlayerPosition);  // se il ray trova e colpisce il player allora true

        if (colpito)
        {
            OnShoot();
            RotateGun();
            FlipGun();
        }
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

        if (hit.collider != null && hit.transform.gameObject.tag == "Player")
        {
            colpito = true;
        }

        Debug.DrawRay(origin, destination - origin, Color.blue, 0.1f);
        Debug.DrawLine(origin, new Vector2(origin.x + range, origin.y), Color.red, 0.1f);  // range del colider

        return colpito;
    }



    void Shoot()
    {
        GenerateBullet();
    }

    void GenerateBullet()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        { // se c'e' posto nel pool 
            bullet.transform.position = GunPoint;
            bullet.SetActive(true);
            bullet.GetComponent<BulletPhysics>().Setup((Direction));
        }
    }

    void RotateGun()
    {
        Vector3 finalAngle = new Vector3(0, 0, GetAngleFromVectorFloat(Direction));
        gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, Quaternion.Euler(finalAngle), rotationSpeed);

        rotationSpeed = rotationSpeed + Time.deltaTime;
        
    }

    void FlipGun() 
    {
        SpriteRenderer gunSprite = gun.GetComponent<SpriteRenderer>();

        //Debug.Log(gun.transform.rotation.eulerAngles.z);

        if (gun.transform.rotation.eulerAngles.z >= 90 && gun.transform.rotation.eulerAngles.z <= 270)
        {
            gunSprite.flipY = true;
            
            GunPoint.x -= GunPoint.x - gun.transform.position.x;
            //Debug.Log("Flippato");
        }

        if (gun.transform.rotation.eulerAngles.z < 90 || gun.transform.rotation.eulerAngles.z > 270)
        {
            gunSprite.flipY = false;
            //Debug.Log("Tornato normale");
        }
    }


    public static float GetAngleFromVectorFloat(Vector2 dir)    // calcola l'angolo data la direzione (serve per ruotare il bullet verso il player)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }


}
