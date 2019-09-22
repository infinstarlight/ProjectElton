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
    public float CurrentAmmo = 0;
    public float MaxAmmo = 0;

    public AudioSource weaponAudio;

    public float nextFire;

    public GameObject weaponProj;
    public GameObject gunEndGO;
    public RaycastHit hit;

     public float fireRate = 0.25f;                                      // Number in seconds which controls how often the player can fire
    float weaponRange = 200f;    

    private bool bCanFire = false;

    void Awake()
    {
        weaponAudio = GetComponent<AudioSource>();
        gunEndGO = GetComponentInChildren<ID_gunEnd>().gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        CheckAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CheckAmmo()
    {
        if(CurrentAmmo > 0)
        {
            bCanFire = true;
        }
        else
        {
            bCanFire = false;
        }
    }
}
