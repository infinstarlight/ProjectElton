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
    //private int styleIndex = 1;




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
                {
                    weaponScript.Fire();
                }
                break;

            case InputActionPhase.Started:
                {
                    if (weaponScript.bIsAutomatic)
                    {
                        weaponScript.StartCoroutine(weaponScript.AutoFire());
                    }
                    if (context.interaction is HoldInteraction)
                    {

                        if (weaponScript.bIsChargeWeapon)
                        {
                            weaponScript.StartCoroutine(weaponScript.ChargeShot());
                        }


                    }
                }
                break;
            case InputActionPhase.Canceled:
                {
                    if (!weaponScript.bIsChargeWeapon)
                    {
                        weaponScript.StopCoroutine(weaponScript.AutoFire());
                    }
                    else
                    {
                        weaponScript.StopCoroutine(weaponScript.ChargeShot());
                        if (weaponScript.CurrentChargeTime > 0)
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
    public void OnPrimaryWeaponSelect(InputAction.CallbackContext context)
    {
        if (currentWeapon != Weapons[0])
        {
            currentWeapon.SetActive(false);
        }
        Weapons[0].SetActive(true);
        weaponScript = Weapons[0].GetComponent<PlayerWeapon>();
        currentWeapon = Weapons[0];

    }

    public void OnSecondWeaponSelect(InputAction.CallbackContext context)
    {
        if (currentWeapon != Weapons[1])
        {
            currentWeapon.SetActive(false);
        }
        Weapons[1].SetActive(true);
        weaponScript = Weapons[1].GetComponent<PlayerWeapon>();
        currentWeapon = Weapons[1];

    }

    public void OnThirdWeaponSelect(InputAction.CallbackContext context)
    {
        if (currentWeapon != Weapons[2])
        {
            currentWeapon.SetActive(false);
        }
        Weapons[2].SetActive(true);
        weaponScript = Weapons[2].GetComponent<PlayerWeapon>();
        currentWeapon = Weapons[2];
    }

    #endregion
}
