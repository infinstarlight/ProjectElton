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
        // var effGO = Resources.Load<GameObject>("Weapons/FireEffect") as GameObject;
        // FireEffect = effGO;
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



            // actual Ray
            Ray ray = Camera.main.ViewportPointToRay(rayOrigin);

            // debug Ray
            Debug.DrawRay(ray.origin, ray.direction * weaponRange, Color.white);
            GameObject VFXGo = Instantiate(FireEffect, gunEndGO.transform.position, PlayerCamera.transform.rotation);

            if (Physics.Raycast(ray, out hit, weaponRange))
            {
                // GameObject beam = Instantiate(weaponProj, gunEndGO.transform.position, Camera.main.transform.rotation);
                if (hit.collider != null)
                {
                     //Debug.Log(hit.collider.gameObject);
                    if (hit.collider.gameObject.GetComponent<Enemy>())
                    {
                        hit.collider.gameObject.GetComponent<Enemy>().OnEnemyDamageApplied(DamageAmount);
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
