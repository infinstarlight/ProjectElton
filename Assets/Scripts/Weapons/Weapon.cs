using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    public enum WeaponType
    {
        None,
        Pistol,
        SMG,
        Rifle,
        Shotgun,
        Launcher,
        Utility
    }
    public enum AmmoType
    {
        None,
        Standard,
        Acidic,
        Ice,

    }

    public WeaponType MyWeaponType;
    public AmmoType MyAmmoType;

    public AudioSource weaponAudio;

    public float nextFire;

    public bool bIsAutomatic = false;
    public GameObject gunEndGO;
    public RaycastHit hit;

    public float DamageAmount = 5.0f;

    public AudioClip[] WeaponSounds;
    private GameObject AIEyes;

    public float fireRate = 0.25f;                                      // Number in seconds which controls how often the player can fire

    //[SerializeField]
    public float weaponRange = 200f;
    public GameObject FireEffect;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    public GameObject WeaponOwner;

    //private bool bCanFire = false;

    void Awake()
    {
        weaponAudio = GetComponent<AudioSource>();
        gunEndGO = GetComponentInChildren<ID_gunEnd>().gameObject;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AIFire()
    {
        if (Time.time > nextFire)
        {
            // Update the time when our player can fire next
            nextFire = Time.time + fireRate;
            Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen



            // actual Ray
            Ray ray = new Ray(AIEyes.transform.position, AIEyes.transform.forward);

            // debug Ray
            Debug.DrawRay(ray.origin, ray.direction * weaponRange, Color.white);
            GameObject VFXGo = Instantiate(FireEffect, gunEndGO.transform.position, transform.rotation);

            if (Physics.Raycast(ray, out hit, weaponRange))
            {
                // GameObject beam = Instantiate(weaponProj, gunEndGO.transform.position, Camera.main.transform.rotation);
                if (hit.collider != null)
                {
                    // Debug.Log(hit.collider.gameObject);
                    if (hit.collider.gameObject.GetComponent<Player>())
                    {
                        hit.collider.gameObject.GetComponent<Player>().OnDamageApplied(DamageAmount);
                    }
                }
            }
        }
    }


    private IEnumerator ShotEffect()
    {
        weaponAudio.clip = WeaponSounds[1];
        // Play the shooting sound effect
        weaponAudio.PlayOneShot(weaponAudio.clip);


        //Wait for .07 seconds
        yield return shotDuration;
    }

}
