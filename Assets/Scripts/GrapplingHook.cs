using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 Direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Direction = MousePos - (Vector2)transform.position;

        FaceMouse();
    }

    void FaceMouse()
    {
        transform.right = Direction;
    }
}
