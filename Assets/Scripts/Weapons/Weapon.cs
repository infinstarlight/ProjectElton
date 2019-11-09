using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
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

    [Header("Weapon Properties")]
    public EWeaponType MyWeaponType;
    public EAmmoType MyAmmoType;
    public bool bIsChargeWeapon = false;
    public bool bIsAutomatic = false;
    public static float s_MaxChargeTime = 0.0f;
    public float MaxChargeLimit = 0.0f;
    //How much has this weapon charged
    public float CurrentChargeTime;
    //How fast can this weapon charge
    public float ChargeModAmount;

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
    public RaycastHit hit;
    public AudioClip[] WeaponSounds;
    public GameObject FireEffect;
    //How high can this weapon charge


    void Awake()
    {
        weaponAudio = GetComponent<AudioSource>();
        gunEndGO = GetComponentInChildren<ID_gunEnd>().gameObject;
        oldDamageAmount = DamageAmount;
        s_MaxChargeTime = MaxChargeLimit;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // // Update is called once per frame
    // void Update()
    // {

    // }




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
        CurrentChargeTime += ChargeModAmount;
        yield return chargeLength   ;
        
    }
    #endregion

}
