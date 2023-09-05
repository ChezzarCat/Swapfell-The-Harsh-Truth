using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveDeath : MonoBehaviour
{
    public static saveDeath instance;
    public int timesDied = 0;

    void Awake ()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
