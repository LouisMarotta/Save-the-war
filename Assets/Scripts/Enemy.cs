using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // https://www.youtube.com/watch?v=qN9UzT_HXEw

    // https://www.youtube.com/watch?v=4ivFemmpYus

    // https://drive.google.com/drive/folders/0B8Zl1dvvnT64Ry03YnJxV2s3TVE



    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform weaponTip;


    public float fireRate = 5f;
    public float range = 60f; // weapon range

    public LayerMask whatToHit;     // l'oggetto che il raycast deve colpire 

    float timeFire = 0;
    Transform firePoint;

    Vector2 PlayerPosition;

    public Vector2 direction;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = GameObject.Find("Player").transform.position;
        ShootRay(GameObject.Find("GunPoint").transform.position, PlayerPosition);
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

    void ShootRay(Vector2 origin, Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction - origin, range, whatToHit);

        Debug.DrawRay(origin, direction - origin, Color.blue, 1f);
        Debug.Log(direction);
    }



    void Shoot()
    {
        Vector2 firePos = new Vector2(weaponTip.position.x, weaponTip.position.y);

        //Vector2 dir = (c_movement.m_FacingRight) ? Vector2.right : Vector2.left;

        //Debug.DrawRay(firePos, dir * range, Color.blue, 1f);
    }

    void WakeUp()
    {

    }

}
