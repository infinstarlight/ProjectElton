using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;

public class InputSystem_PlayerCombatController : MonoBehaviour
{
    public PlayerStatsScript playerStats;
    public GameObject currentWeapon;
    private AudioSource styleAudioSource;
    public AudioClip[] styleClips;

    public GameObject[] Weapons;
    private PlayerWeapon weaponScript;
    private bool bIsAutoFiring = false;
    private bool bIsCharging = false;
    private int weaponCount = 0;




    void Awake()
    {
        styleAudioSource = GetComponent<AudioSource>();
        playerStats = GetComponentInParent<PlayerStatsScript>();
        currentWeapon = Weapons[0];
        Weapons[1].gameObject.SetActive(false);
        Weapons[2].gameObject.SetActive(false);
        weaponScript = currentWeapon.GetComponent<PlayerWeapon>();

    }

    // Update is called once per frame
    void Update()
    {
        //If we can get the right GameObject, but not the right PlayerScript reference
        if (currentWeapon.GetComponent<PlayerWeapon>())
        {
            if (weaponScript == null)
            {
                weaponScript = currentWeapon.GetComponent<PlayerWeapon>();
            }
            if (weaponScript.bIsAutomatic && bIsAutoFiring)
            {
                weaponScript.StartCoroutine(weaponScript.AutoFire());
            }
            if (weaponScript.bIsChargeWeapon && bIsCharging)
            {
                weaponScript.StartCoroutine(weaponScript.ChargeShot());
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
                weaponScript.Fire();
                break;

            case InputActionPhase.Started:
                {
                    {

                        if (weaponScript.bIsChargeWeapon)
                        {
                            bIsCharging = true;
                            //weaponScript.StartCoroutine(weaponScript.ChargeShot());
                        }
                        if (weaponScript.bIsAutomatic)
                        {
                            bIsAutoFiring = true;
                            //weaponScript.StartCoroutine(weaponScript.AutoFire());
                        }
                    }
                }
                break;
            case InputActionPhase.Canceled:
                {
                    if (weaponScript.bIsAutomatic)
                    {
                        bIsAutoFiring = false;
                        weaponScript.StopCoroutine(weaponScript.AutoFire());
                    }
                    if (weaponScript.bIsChargeWeapon)
                    {
                        bIsCharging = false;
                        weaponScript.StopCoroutine(weaponScript.ChargeShot());
                        if (weaponScript.CurrentChargeAmount > 0)
                        {
                            weaponScript.FireChargedShot();
                        }
                    }


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
        weaponScript = Weapons[weaponDesired].GetComponent<PlayerWeapon>();
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
