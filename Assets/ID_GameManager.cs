using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID_GameManager : MonoBehaviour
{

    private static ID_GameManager instance = null;
    public static ID_GameManager Instance { get { return instance; } }


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}
