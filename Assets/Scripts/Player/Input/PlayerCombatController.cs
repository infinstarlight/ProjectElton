using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{

    public GameObject currentWeapon;
    
    public GameObject[] Weapons;
    private PlayerWeapon weaponScript;
    private PlayerController pCon;
    // Start is called before the first frame update
    void Start()
    {
        pCon = GetComponent<PlayerController>();
        currentWeapon = Weapons[0];
        Weapons[1].gameObject.SetActive(false);
        
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
                if (Input.GetButton("Attack"))
                {
                    if (weaponScript.bIsAutomatic)
                    {
                        weaponScript.StartCoroutine(weaponScript.AutoFire());
                    }
                }
                if (Input.GetButtonDown("Attack"))
                {

                    weaponScript.Fire();

                }
            }
            if (Input.GetButtonUp("Attack"))
            {
                if (weaponScript.bIsAutomatic)
                {
                    weaponScript.StopCoroutine(weaponScript.AutoFire());
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(currentWeapon != Weapons[0])
            {
                currentWeapon.SetActive(false);
            }
            Weapons[0].SetActive(true);
            weaponScript = Weapons[0].GetComponent<PlayerWeapon>();
            currentWeapon = Weapons[0];
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
             if(currentWeapon != Weapons[1])
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
}
