using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;

public class InputSystem_PlayerCombatController : MonoBehaviour
{
    private PlayerStatsScript playerStats;
    public GameObject currentWeapon;

    public GameObject[] Weapons;
    private PlayerWeapon weaponScript;
    private int styleIndex = 1;
    //private PlayerController pCon;



    void Awake()
    {
        playerStats = GetComponentInParent<PlayerStatsScript>();
        //pCon = GetComponent<PlayerController>();
        currentWeapon = Weapons[0];
        Weapons[1].gameObject.SetActive(false);
        weaponScript = currentWeapon.GetComponent<PlayerWeapon>();

    }

    // Update is called once per frame
    void Update()
    {

        if (currentWeapon.GetComponent<PlayerWeapon>())
        {
            if (weaponScript == null)
            {
                weaponScript = currentWeapon.GetComponent<PlayerWeapon>();
            }
        }
    }

    void FindPrimaryWeapon()
    {

    }

    public void StyleSwitcher(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                {
                    playerStats.ModifyCurrentStyle();
                }
                break;
            case InputActionPhase.Canceled:
                {

                }
                break;
        }

    }

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
                    if (context.interaction is HoldInteraction)
                    {
                        weaponScript.StartCoroutine(weaponScript.AutoFire());
                    }
                }
                break;
            case InputActionPhase.Canceled:
                {
                    weaponScript.StopCoroutine(weaponScript.AutoFire());
                }
                break;
        }
    }

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
}
