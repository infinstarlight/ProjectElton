using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : Weapon
{
    public AIControllerBase GetAICon;
    //Temp variable to keep AI from instantly killing the player
    public float ShotWaitPeriod = 3.0f;
    public GameObject AIEyes;
    // Start is called before the first frame update
    void Start()
    {
        weaponAudio = GetComponent<AudioSource>();
        gunEndGO = GetComponentInChildren<ID_gunEnd>().gameObject;
        GetAICon = GetComponentInParent<AIControllerBase>();
        AIEyes = GetAICon.AIEyes;
    }


    public void AIFire()
    {
        if (Time.time > nextFire)
        {
            // Update the time when our player can fire next
            nextFire = Time.time + fireRate + ShotWaitPeriod;
            Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen



            // actual Ray
            Ray ray = new Ray(AIEyes.transform.position,AIEyes.transform.forward);

            // debug Ray
            Debug.DrawRay(ray.origin, ray.direction * weaponRange, Color.white);
            GameObject VFXGo = Instantiate(FireEffect, gunEndGO.transform.position, AIEyes.transform.rotation);

            if (Physics.Raycast(ray, out hit, weaponRange))
            {
                // GameObject beam = Instantiate(weaponProj, gunEndGO.transform.position, Camera.main.transform.rotation);
                if (hit.collider != null)
                {
                    // Debug.Log(hit.collider.gameObject);
                    if (hit.collider.gameObject.GetComponent<Player>())
                    {
                        hit.collider.gameObject.GetComponent<Player>().PlayerDamageTaken(DamageAmount);
                    }
                }
            }
        }
    }
}
