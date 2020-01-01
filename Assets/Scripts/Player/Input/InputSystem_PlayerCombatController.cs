using UnityEngine.InputSystem;
using UnityEngine;

public class InputSystem_PlayerCombatController : MonoBehaviour
{
    public PlayerStatsScript playerStats;
    public GameObject currentWeaponGO;
    public GameObject currentSubWeaponGO;
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
        currentWeaponGO = Weapons[0];
        Weapons[1].gameObject.SetActive(false);
        Weapons[2].gameObject.SetActive(false);
        currentWeaponScript = currentWeaponGO.GetComponent<PlayerWeapon>();
        currentSubWeaponGO = GetComponentInChildren<Subweapon>().gameObject;
        currentSubweaponScript = currentSubWeaponGO.GetComponent<Subweapon>();

    }

    // Update is called once per frame
    void Update()
    {
        //If we can get the right GameObject, but not the right PlayerScript reference
        if (currentWeaponGO.GetComponent<PlayerWeapon>())
        {
            if (currentWeaponScript == null)
            {
                currentWeaponScript = currentWeaponGO.GetComponent<PlayerWeapon>();
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
        if (currentSubWeaponGO.GetComponent<Subweapon>())
        {
            if (!currentSubweaponScript)
            {
                currentSubweaponScript = currentSubWeaponGO.GetComponent<Subweapon>();
            }
        }

        if (Application.isEditor || Debug.isDebugBuild)
        {
            if (Keyboard.current.gKey.wasPressedThisFrame)
            {
                bEnableGodMode = !bEnableGodMode;
                if (bEnableGodMode)
                {
                    currentWeaponScript.DamageAmount = 9999;
                    currentSubweaponScript.DamageAmount = 9999;
                    currentSubweaponScript.bCanConsumeAmmo = false;
                }
                else
                {
                    currentWeaponScript.RevertDamage();
                    currentSubweaponScript.RevertDamage();
                    currentSubweaponScript.bCanConsumeAmmo = true;
                }
            }
        }
    }


    //Thanks to the new Input System
    public void OnFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                {
                    if (!currentWeaponScript.bIsChargeWeapon)
                    {
                        currentWeaponScript.Fire();
                    }

                    if (Gamepad.current != null)
                    {
                        Gamepad.current.SetMotorSpeeds(0.25f, 0.75f);
                    }

                }

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
                    if (Gamepad.current != null)
                    {
                        Gamepad.current.SetMotorSpeeds(0.0f, 0.0f);
                    }

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
        if (currentWeaponGO != Weapons[weaponDesired])
        {
            currentWeaponGO.SetActive(false);
        }
        Weapons[weaponDesired].SetActive(true);
        currentWeaponScript = Weapons[weaponDesired].GetComponent<PlayerWeapon>();
        currentWeaponGO = Weapons[weaponDesired];
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
        if (weaponCount >= Weapons.Length)
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
