﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{

    void Awake()
    {
        if (Time.timeScale <= 0)
        {
            Time.timeScale = 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // void Update()
    // {

    // }
}
