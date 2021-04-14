using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public GameObject bg0;
    // Start is called before the first frame update
    void Start()
    {
        bg0 = gameObject.transform.Find("0").gameObject;
        //bg0.transform.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
