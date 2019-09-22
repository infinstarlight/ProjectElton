using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : Weapon
{

    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if(Time.time > nextFire)
        {
              // Start our ShotEffect coroutine to turn our laser line on and off
                StartCoroutine(ShotEffect());
                
                // Update the time when our player can fire next
                nextFire = Time.time + fireRate;
                Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen

                float rayLength = 200f;

                // actual Ray
                Ray ray = Camera.main.ViewportPointToRay(rayOrigin);

                // debug Ray
                Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);


                if (Physics.Raycast(ray, out hit, rayLength))
                {
                    GameObject beam = Instantiate(weaponProj, gunEndGO.transform.position, Camera.main.transform.rotation);
                    //SFXInstance.SoundDesired = 3;
                }
        }
    }

    private IEnumerator ShotEffect()
    {
        
        // Play the shooting sound effect
        weaponAudio.PlayOneShot(weaponAudio.clip);

        //Wait for .07 seconds
        yield return shotDuration;
    }
}
