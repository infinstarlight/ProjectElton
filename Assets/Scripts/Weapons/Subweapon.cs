using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ESubWeaponType
{
    None,
    MiniMissiles,
    Flamethrower,
    Needler
}

public class Subweapon : Weapon
{
    public ESubWeaponType mySubWeaponType;

    public float CurrentAmmo = 0;
    public float MaxAmmo = 0;
    public UnityEvent activateEvent = new UnityEvent();
    public UnityEvent deactivateEvent = new UnityEvent();
    public bool bCanConsumeAmmo = false;
    // Start is called before the first frame update
    void Start()
    {
        CurrentAmmo = MaxAmmo;
    }

    public void ModifyAmmo(float ModAmount)
    {
        if (CurrentAmmo < MaxAmmo)
        {
            CurrentAmmo += ModAmount;
        }
        else
        {
            CurrentAmmo = MaxAmmo;
        }
    }


}
