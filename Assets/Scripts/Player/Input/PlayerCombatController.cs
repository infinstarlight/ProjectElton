using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    public InputAction fireAction;
    public GameObject currentWeapon;

    public GameObject[] Weapons;
    private PlayerWeapon weaponScript;
    private PlayerController pCon;

    void OnEnable()
    {
        fireAction.Enable();
    }

    void OnDisable()
    {
        fireAction.Disable();
    }


    void Awake()
    {
        pCon = GetComponent<PlayerController>();
        currentWeapon = Weapons[0];
        Weapons[1].gameObject.SetActive(false);
        weaponScript = currentWeapon.GetComponent<PlayerWeapon>();
        fireAction.performed += ctx => weaponScript.Fire();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pCon.bIsGamePaused || !pCon.bEnableInput)
        {
            if (currentWeapon.GetComponent<PlayerWeapon>())
            {
                if (weaponScript == null)
                {
                    weaponScript = currentWeapon.GetComponent<PlayerWeapon>();
                }
            //     if (Input.GetButton("Attack"))
            //     {
            //         if (weaponScript.bIsAutomatic)
            //         {
            //             weaponScript.StartCoroutine(weaponScript.AutoFire());
            //         }
            //     }
            //     if (Input.GetButtonDown("Attack"))
            //     {

            //         weaponScript.Fire();

            //     }
            // }
            // if (Input.GetButtonUp("Attack"))
            // {
            //     if (weaponScript.bIsAutomatic)
            //     {
            //         weaponScript.StopCoroutine(weaponScript.AutoFire());
            //     }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentWeapon != Weapons[0])
            {
                currentWeapon.SetActive(false);
            }
            Weapons[0].SetActive(true);
            weaponScript = Weapons[0].GetComponent<PlayerWeapon>();
            currentWeapon = Weapons[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
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

    void FindPrimaryWeapon()
    {

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
}
