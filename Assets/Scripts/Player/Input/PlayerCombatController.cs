using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{

    public GameObject currentWeapon;
    private PlayerWeapon weaponScript;
    private PlayerController pCon;
    // Start is called before the first frame update
    void Start()
    {
        pCon = GetComponent<PlayerController>();
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
                if (Input.GetButton("Fire1"))
                {
                    if (weaponScript.bIsAutomatic)
                    {
                        weaponScript.StartCoroutine(weaponScript.AutoFire());
                    }
                }
                if (Input.GetButtonDown("Fire1"))
                {

                    weaponScript.Fire();

                }
            }
            if (Input.GetButtonUp("Fire1"))
            {
                if (weaponScript.bIsAutomatic)
                {
                    weaponScript.StopCoroutine(weaponScript.AutoFire());
                }
            }
        }

    }
}
