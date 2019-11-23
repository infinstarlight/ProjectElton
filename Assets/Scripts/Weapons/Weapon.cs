using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EWeaponType
{
    None,
    Pistol,
    SMG,
    Rifle,
    Shotgun,
    Launcher,
    Utility
}
public enum EAmmoType
{
    None,
    Standard,
    Acidic,
    Ice,

}
[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{


    [Header("Weapon Properties")]
    public EWeaponType MyWeaponType;
    public EAmmoType MyAmmoType;
    public bool bIsChargeWeapon = false;
    public bool bIsAutomatic = false;
    public static float s_MaxChargeTime = 0.0f;
    public float MaxChargeLimit = 0.0f;
    //How much has this weapon charged
    public float CurrentChargeAmount;
    //How fast can this weapon charge
    public float ChargeModAmount = 0.01f;
    public float ChargeModRate = 1;

    public WaitForSeconds chargeLength = new WaitForSeconds(s_MaxChargeTime);

    public WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

    public float weaponRange = 200f;
    public float nextFire;
    [Header("Damage Stats")]
    public float fireRate = 0.25f;       // Number in seconds which controls how often the player can fire
    public float DamageAmount = 5.0f;
    public float oldDamageAmount = 0.0f;

    [Header("VFX & SFX")]
    public AudioSource weaponAudio;
    public GameObject gunEndGO;
    
    public AudioClip[] WeaponSounds;
    public GameObject FireEffect;
    public RaycastHit hit;
    public Ray weaponRay;
    public Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0.0f);
    public bool bIsPlayerWeapon = false;
    //What object does the owner use to aim
    public GameObject aimGO;



    void Awake()
    {
        weaponAudio = GetComponent<AudioSource>();
        gunEndGO = GetComponentInChildren<ID_gunEnd>().gameObject;
        oldDamageAmount = DamageAmount;
        s_MaxChargeTime = MaxChargeLimit;

    }

    public void Fire()
    {
        if (Time.time > nextFire)
        {
            // Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine(ShotEffect());

            // Update the time when our player can fire next
            nextFire = Time.time + fireRate;


            GameObject hitObject = null;
            LoadingDoorScript hitDoor = null;
            WeaponChargeObject hitChargeObject = null;

            // actual Ray
            if (bIsPlayerWeapon)
            {
                if (aimGO.GetComponent<Camera>())
                {
                    weaponRay = aimGO.GetComponent<Camera>().ViewportPointToRay(rayOrigin);
                }
            }
            else
            {
                weaponRay = new Ray(aimGO.transform.position, aimGO.transform.forward);
            }

            // debug Ray
            Debug.DrawRay(weaponRay.origin, weaponRay.direction * weaponRange, Color.white);
            Instantiate(FireEffect, gunEndGO.transform.position, aimGO.transform.rotation);

            if (Physics.Raycast(weaponRay, out hit, weaponRange))
            {

                if (hit.collider != null)
                {
                    hitObject = hit.collider.gameObject;
                    if (bIsPlayerWeapon)
                    {
                        if (hitObject.GetComponent<Enemy>())
                        {
                            hitObject.GetComponent<Enemy>().damageEvent.Invoke(DamageAmount);
                        }
                        if (hitObject.GetComponentInChildren<ID_LoadDoor>())
                        {
                            hitDoor = hitObject.GetComponentInParent<LoadingDoorScript>();
                            hitDoor.CheckAmmoType(MyAmmoType);
                            //TODO: If it's the wrong ammo type, bounce the shot back to player
                        }
                        if (hitObject.GetComponent<WeaponChargeObject>())
                        {
                            float chargeAmount = DamageAmount / 4;
                            hitChargeObject = hitObject.GetComponent<WeaponChargeObject>();
                            hitChargeObject.ModCharge(chargeAmount, MyAmmoType);
                        }
                    }
                    if (!bIsPlayerWeapon)
                    {
                        if (hit.collider.gameObject.GetComponent<Player>())
                        {
                            hit.collider.gameObject.GetComponent<Player>().PlayerDamageTaken(DamageAmount);
                        }
                    }


                }
            }
        }
    }

    public void FireChargedShot()
    {
        DamageAmount *= CurrentChargeAmount;
        Fire();
        DamageAmount = oldDamageAmount;
        CurrentChargeAmount = 0;
    }

    public IEnumerator AutoFire()
    {
        //Debug.Log("Fire!");
        Fire();
        yield return fireRate;
    }


    public IEnumerator ShotEffect()
    {
        weaponAudio.clip = WeaponSounds[1];
        // Play the shooting sound effect
        weaponAudio.PlayOneShot(weaponAudio.clip);


        //Wait for .07 seconds
        yield return shotDuration;
    }

    #region Charge Type Weapon
    public IEnumerator ChargeShot()
    {
        if (CurrentChargeAmount <= MaxChargeLimit)
        {
            CurrentChargeAmount += ChargeModAmount;
        }

        yield return ChargeModRate;

    }
    #endregion

}
