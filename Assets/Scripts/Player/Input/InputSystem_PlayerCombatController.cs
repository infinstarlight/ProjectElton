using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;

public class InputSystem_PlayerCombatController : MonoBehaviour
{
    public PlayerStatsScript playerStats;
    public GameObject currentWeapon;
    public GameObject currentSubWeapon;
    private AudioSource styleAudioSource;
    public AudioClip[] styleClips;

    public GameObject[] Weapons;
    private PlayerWeapon currentWeaponScript;
    private Subweapon currentSubweaponScript;
    private bool bIsAutoFiring = false;
    private bool bIsCharging = false;
    private int weaponCount = 0;
    private bool bEnableGodMode = false;




    void Awake()
    {
        styleAudioSource = GetComponent<AudioSource>();
        playerStats = GetComponentInParent<PlayerStatsScript>();
        currentWeapon = Weapons[0];
        Weapons[1].gameObject.SetActive(false);
        Weapons[2].gameObject.SetActive(false);
        currentWeaponScript = currentWeapon.GetComponent<PlayerWeapon>();
        currentSubWeapon = GetComponentInChildren<Subweapon>().gameObject;
        currentSubweaponScript = currentSubWeapon.GetComponent<Subweapon>();

    }

    // Update is called once per frame
    void Update()
    {
        //If we can get the right GameObject, but not the right PlayerScript reference
        if (currentWeapon.GetComponent<PlayerWeapon>())
        {
            if (currentWeaponScript == null)
            {
                currentWeaponScript = currentWeapon.GetComponent<PlayerWeapon>();
            }
            if (currentWeaponScript.bIsAutomatic && bIsAutoFiring)
            {
                currentWeaponScript.StartCoroutine(currentWeaponScript.AutoFire());
            }
            if (currentWeaponScript.bIsChargeWeapon && bIsCharging)
            {
                currentWeaponScript.StartCoroutine(currentWeaponScript.ChargeShot());
            }
        }
        if(currentSubWeapon.GetComponent<Subweapon>())
        {
            if(!currentSubweaponScript)
            {
                currentSubweaponScript = currentSubWeapon.GetComponent<Subweapon>();
            }
        }

         if (Application.isEditor || Debug.isDebugBuild)
         {
             if(Keyboard.current.gKey.wasPressedThisFrame)
             {
                 bEnableGodMode = !bEnableGodMode;
                 if(bEnableGodMode)
                 {
                     currentWeaponScript.DamageAmount = 9999;
                     currentSubweaponScript.DamageAmount = 9999;
                     currentSubweaponScript.bCanConsumeAmmo = false;
                 }
                 else
                 {
                     currentWeaponScript.DamageAmount = currentWeaponScript.oldDamageAmount;
                     currentSubweaponScript.DamageAmount = currentSubweaponScript.oldDamageAmount;
                     currentSubweaponScript.bCanConsumeAmmo = true;
                 }
             }
         }
    }

    public void OnStyleSwitchDown(InputAction.CallbackContext context)
    {
        playerStats.ModifyCurrentStyleDown();
        switch (playerStats.pcStats.currentCharacterStyle)
        {
            case CharacterStats.ECharacterStyle.Offense:
                {
                    styleAudioSource.clip = styleClips[0];
                    styleAudioSource.PlayOneShot(styleAudioSource.clip);
                }
                break;
            case CharacterStats.ECharacterStyle.Defense:
                {
                    styleAudioSource.clip = styleClips[1];
                    styleAudioSource.PlayOneShot(styleAudioSource.clip);
                }
                break;
            case CharacterStats.ECharacterStyle.Speed:
                {
                    styleAudioSource.clip = styleClips[2];
                    styleAudioSource.PlayOneShot(styleAudioSource.clip);
                }
                break;
            case CharacterStats.ECharacterStyle.Regen:
                {
                    styleAudioSource.clip = styleClips[3];
                    styleAudioSource.PlayOneShot(styleAudioSource.clip);
                }
                break;
        }
    }

    public void OnStyleSwitchUp(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                {
                    playerStats.ModifyCurrentStyleUp();
                    switch (playerStats.pcStats.currentCharacterStyle)
                    {
                        case CharacterStats.ECharacterStyle.Offense:
                            {
                                styleAudioSource.clip = styleClips[0];
                                styleAudioSource.PlayOneShot(styleAudioSource.clip);
                            }
                            break;
                        case CharacterStats.ECharacterStyle.Defense:
                            {
                                styleAudioSource.clip = styleClips[1];
                                styleAudioSource.PlayOneShot(styleAudioSource.clip);
                            }
                            break;
                        case CharacterStats.ECharacterStyle.Speed:
                            {
                                styleAudioSource.clip = styleClips[2];
                                styleAudioSource.PlayOneShot(styleAudioSource.clip);
                            }
                            break;
                        case CharacterStats.ECharacterStyle.Regen:
                            {
                                styleAudioSource.clip = styleClips[3];
                                styleAudioSource.PlayOneShot(styleAudioSource.clip);
                            }
                            break;
                    }
                }
                break;
            case InputActionPhase.Canceled:
                {

                }
                break;
        }

    }

    //Thanks to the new Input System
    public void OnFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                currentWeaponScript.Fire();
                break;

            case InputActionPhase.Started:
                {
                    {

                        if (currentWeaponScript.bIsChargeWeapon)
                        {
                            bIsCharging = true;
                            //weaponScript.StartCoroutine(weaponScript.ChargeShot());
                        }
                        if (currentWeaponScript.bIsAutomatic)
                        {
                            bIsAutoFiring = true;
                            //weaponScript.StartCoroutine(weaponScript.AutoFire());
                        }
                    }
                }
                break;
            case InputActionPhase.Canceled:
                {
                    if (currentWeaponScript.bIsAutomatic)
                    {
                        bIsAutoFiring = false;
                        currentWeaponScript.StopCoroutine(currentWeaponScript.AutoFire());
                    }
                    if (currentWeaponScript.bIsChargeWeapon)
                    {
                        bIsCharging = false;
                        currentWeaponScript.StopCoroutine(currentWeaponScript.ChargeShot());
                        if (currentWeaponScript.CurrentChargeAmount > 0)
                        {
                            currentWeaponScript.FireChargedShot();
                        }
                    }


                }
                break;
        }
    }

    public void OnSubFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
            {
                currentSubweaponScript.activateEvent.Invoke();
            }
            break;
            case InputActionPhase.Canceled:
            {
                currentSubweaponScript.deactivateEvent.Invoke();
            }
            break;
                
        }
    }

    //These functions are all basically the same, but for the sake of laziness - they are all separate for now
    #region Weapon Selection

    void WeaponSelect(int weaponDesired)
    {
        if (currentWeapon != Weapons[weaponDesired])
        {
            currentWeapon.SetActive(false);
        }
        Weapons[weaponDesired].SetActive(true);
        currentWeaponScript = Weapons[weaponDesired].GetComponent<PlayerWeapon>();
        currentWeapon = Weapons[weaponDesired];
    }

    void CycleWeapon(bool bShouldCycleUp)
    {
        if (weaponCount <= Weapons.Length)
        {
            if (bShouldCycleUp)
            {
                WeaponSelect(++weaponCount);
            }
            else
            {
                WeaponSelect(weaponCount--);
            }
        }
        if(weaponCount >= Weapons.Length)
        {
            weaponCount = 0;
        }


    }

    public void OnWeaponCycleUp(InputAction.CallbackContext context)
    {
        CycleWeapon(true);
    }

    public void OnWeaponCycleDown(InputAction.CallbackContext context)
    {
        CycleWeapon(false);
    }

    public void OnPrimaryWeaponSelect(InputAction.CallbackContext context)
    {

        WeaponSelect(0);
    }

    public void OnSecondWeaponSelect(InputAction.CallbackContext context)
    {

        WeaponSelect(1);

    }

    public void OnThirdWeaponSelect(InputAction.CallbackContext context)
    {

        WeaponSelect(2);
    }



    #endregion
}
