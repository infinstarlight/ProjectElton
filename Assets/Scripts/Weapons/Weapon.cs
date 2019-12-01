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
    public float DamageAmount = 0.0f;
    public float baseDamage = 5.0f;
    public float damageModifer = 0.0f;
    public float oldDamageModifer = 0.0f;
    public float oldbaseDamage = 0.0f;

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
    private GameObject hitObject = null;
    private LoadingDoorScript hitDoor = null;
    private WeaponChargeObject hitChargeObject = null;
    private Character weaponOwner;




    void Awake()
    {
        weaponAudio = GetComponent<AudioSource>();
        gunEndGO = GetComponentInChildren<ID_gunEnd>().gameObject;
        oldbaseDamage = baseDamage;
        oldDamageModifer = damageModifer;
        DamageAmount = baseDamage + damageModifer;

        s_MaxChargeTime = MaxChargeLimit;
        weaponOwner = GetComponentInParent<Character>();

    }

    public void Fire()
    {
        if (Time.time > nextFire)
        {
            // Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine(ShotEffect());

            // Update the time when our player can fire next
            nextFire = Time.time + fireRate;



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
                            // if(hitDoor.bIsLocked && hitDoor.doorKey)
                            // {

                            // }
                            hitDoor.SendMessage("CheckAmmoType", MyAmmoType);

                            //TODO: If it's the wrong ammo type, bounce the shot back to player
                        }
                        if (hitObject.GetComponent<WeaponChargeObject>())
                        {
                            float chargeAmount = DamageAmount / 4;
                            hitChargeObject = hitObject.GetComponent<WeaponChargeObject>();
                            hitChargeObject.ModCharge(chargeAmount, MyAmmoType);
                        }
                        if (hitObject.GetComponent<TurretController>())
                        {
                            hitObject.GetComponent<TurretController>().OnDamageApplied(DamageAmount);
                            //hitObject.GetComponent<TurretController>().SendMessage("RotateToTarget",weaponOwner.gameObject);
                        }
                    }
                    if (!bIsPlayerWeapon)
                    {
                        if (hitObject.GetComponent<Player>())
                        {

                            hitObject.SendMessage("PlayerDamageTaken", DamageAmount);
                        }
                    }


                }
            }
        }
    }

    public void ModifyDamage(float damageMod)
    {
        damageModifer = damageMod;
        DamageAmount = baseDamage + damageModifer;
    }

    public void RevertDamage()
    {
        DamageAmount = oldbaseDamage + oldDamageModifer;
    }

    public void FireChargedShot()
    {
        DamageAmount *= CurrentChargeAmount;
        Fire();
        RevertDamage();
        CurrentChargeAmount = 0;
    }

    public IEnumerator AutoFire()
    {
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
