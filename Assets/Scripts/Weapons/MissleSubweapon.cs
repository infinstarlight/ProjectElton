using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleSubweapon : Subweapon, ISubWeapon
{
    private Camera playerCamera;
    public GameObject missileGO;


    private void Awake()
    {
        MaxAmmo = 25;
        playerCamera = Camera.main;
        CurrentAmmo = MaxAmmo;

    }
    // Start is called before the first frame update
    void Start()
    {
        activateEvent.AddListener(OnSubweaponActivate);
        deactivateEvent.AddListener(OnSubweaponDeactivate);
    }

    private void OnDisable()
    {
        activateEvent.RemoveAllListeners();
        deactivateEvent.RemoveAllListeners();
    }

    public void OnSubweaponActivate()
    {
        if (CurrentAmmo > 0)
        {
            weaponRay = playerCamera.ViewportPointToRay(rayOrigin);
            if (Time.time > nextFire)
            {
                // Update the time when our player can fire next
                nextFire = Time.time + fireRate;
                Instantiate(missileGO, gunEndGO.transform.position, aimGO.transform.rotation);
                CurrentAmmo--;
            }
        }
        else
        {
            Debug.Log("Out of Ammo!");
        }
    }

    public void OnSubweaponDeactivate()
    {

    }


}
