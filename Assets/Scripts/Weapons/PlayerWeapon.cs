using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : Weapon
{
    //private bool bIsFiring = false;
    //private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

    private Camera PlayerCamera;
    
   

    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera = Camera.main;
     
    }

    void Update()
    {
        if(!PlayerCamera)
        {
            PlayerCamera = Camera.main;
        }
    }

    public void Fire()
    {
        if (Time.time > nextFire)
        {
            // Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine(ShotEffect());

            // Update the time when our player can fire next
            nextFire = Time.time + fireRate;
            Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen

            GameObject hitObject = null;
            LoadingDoorScript hitDoor = null;
            WeaponChargeObject hitChargeObject = null;

            // actual Ray
            Ray ray = PlayerCamera.ViewportPointToRay(rayOrigin);

            // debug Ray
            Debug.DrawRay(ray.origin, ray.direction * weaponRange, Color.white);
            GameObject VFXGo = Instantiate(FireEffect, gunEndGO.transform.position, PlayerCamera.transform.rotation);

            if (Physics.Raycast(ray, out hit, weaponRange))
            {
                
                if (hit.collider != null)
                {
                    hitObject = hit.collider.gameObject;
                     //Debug.Log(hit.collider.gameObject);
                    if (hitObject.GetComponent<Enemy>())
                    {

                        hitObject.GetComponent<Enemy>().damageEvent.Invoke(DamageAmount);
                    }
                    if(hitObject.GetComponentInChildren<ID_LoadDoor>())
                    {
                        hitDoor = hitObject.GetComponentInParent<LoadingDoorScript>();
                        hitDoor.CheckAmmoType(MyAmmoType);
                        //TODO: If it's the wrong ammo type, bounce the shot back to player
                    }
                    if(hitObject.GetComponent<WeaponChargeObject>())
                    {
                        float chargeAmount = DamageAmount / 4;
                        hitChargeObject = hitObject.GetComponent<WeaponChargeObject>();
                        hitChargeObject.ModCharge(chargeAmount,MyAmmoType);
                    }
                }
            }
        }
    }

   public void FireChargedShot()
   {
       DamageAmount *= CurrentChargeTime;
       Fire();
       DamageAmount = oldDamageAmount;
       CurrentChargeTime = 0;
   }

    public IEnumerator AutoFire()
    {
        Fire();
        yield return fireRate;
    }
}
