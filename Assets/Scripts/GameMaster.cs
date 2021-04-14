using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckPointPos;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)   // se non funziona qualcosa vedi questo https://www.youtube.com/watch?v=ofCLJsSUom0
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
