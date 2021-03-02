using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 shootDir;
    public void Setup(Vector2 shootDir)
    {
        this.shootDir = shootDir;
    }

    
}
