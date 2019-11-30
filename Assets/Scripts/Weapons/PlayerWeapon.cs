using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : Weapon
{

    private Camera PlayerCamera;
    private GameObject cameraGO;



    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera = Camera.main;
        cameraGO = PlayerCamera.gameObject;
        
        aimGO = cameraGO;
        aimGO = cameraGO;
        bIsPlayerWeapon = true;
    }

    void Update()
    {
        if (!PlayerCamera)
        {
            PlayerCamera = Camera.main;
        }
    }




}
