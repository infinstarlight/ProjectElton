﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float rotateSpeed;
    public Vector3 Rotation = new Vector3(0, 45, 0);

    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Rotation * rotateSpeed);
    }
}
