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
        weaponAudio = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start()
    {
        activateEvent.AddListener(OnSubweaponActivate);
        deactivateEvent.AddListener(OnSubweaponDeactivate);
        if(!bCanConsumeAmmo)
        {
            bCanConsumeAmmo = true;
        }
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
            Instantiate(FireEffect, gunEndGO.transform.position, aimGO.transform.rotation);
            if (Time.time > nextFire)
            {
                // Update the time when our player can fire next
                nextFire = Time.time + fireRate;

                Instantiate(missileGO, gunEndGO.transform.position, aimGO.transform.rotation);
                if (bCanConsumeAmmo)
                {
                    --CurrentAmmo;
                }

                if (weaponAudio.clip != WeaponSounds[2])
                {
                    weaponAudio.clip = WeaponSounds[2];
                }
                weaponAudio.PlayOneShot(weaponAudio.clip);
            }
        }
        else
        {
            Debug.Log("Out of Ammo!");
            if (weaponAudio.clip != WeaponSounds[3])
            {
                weaponAudio.clip = WeaponSounds[3];
            }
            weaponAudio.PlayOneShot(weaponAudio.clip);
        }
    }

    public void OnSubweaponDeactivate()
    {

    }


}
