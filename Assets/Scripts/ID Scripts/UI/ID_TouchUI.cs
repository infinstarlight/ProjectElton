using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID_TouchUI : MonoBehaviour
{

    private static ID_TouchUI instance = null;
    public static ID_TouchUI Instance { get { return instance; } }

    private void Awake()
    {
        // if (instance != null && instance != this)
        // {
        //     Destroy(gameObject);
        //     return;
        // }
        // instance = this;
        // DontDestroyOnLoad(this);
    }

    private void Start()
    {

    }
}
