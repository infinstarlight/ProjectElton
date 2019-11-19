using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        CurrentAmmo = MaxAmmo;
    }

    public void ModifyAmmo(float ModAmount)
    {
        if(CurrentAmmo != MaxAmmo)
        {
            CurrentAmmo += ModAmount;
        }
        else
        {
            CurrentAmmo = MaxAmmo;
        }
    }
  
}
