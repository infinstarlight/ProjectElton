using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerStatsScript : MonoBehaviour
{
    public enum ECharacterActions
    {
        None,
        Dash,
        Regen,
        Booster,
    }
    public enum ESpecialAbility
    {
        None,
        SlowTime,
        Aragon,
        Berserk
    }
    public CharacterStats pcStats;
    public Player player;
    public ECharacterActions currentCharacterAction;
    public ESpecialAbility currentSpecialAbility;


    private bool bIsDebug = false;
    Keyboard currentKeyboard;
    private PlayerStateScript GetPlayerState;
    private PlayerUIController GetPlayerUI;
    private InputSystem_PlayerController GetPlayerController;
    public UnityEvent updateDataEvent = new UnityEvent();
    public float CurrentPower = 0.0f;
    public float MaxPower = 0.0f;
    public float PowerGaugePercentage = 0.0f;
    public bool bIsPowerGaugeEnabled = false;
    public float playerHealthPercentage = 0.0f;
    public float PowerConsumeAmount = 0.0f;
    public float PowerConsumeRate = 0.0f;
    public float DamageMultiplierAmount = 0.0f;
    public float SlowTimeAmount = 0.0f;
    public float HealthRegenAmount = 0.0f;
    public float HealthRegenRate = 0.0f;
    private bool bStartPower = false;
    private bool bStartHealthRegen = false;
    public UnityEvent activateSpecialEvent = new UnityEvent();
    public UnityEvent deactivateSpecialEvent = new UnityEvent();
    public static UnityEvent toggleGodModeEvent = new UnityEvent();
    public UnityFloatEvent modPowerEvent = new UnityFloatEvent();
    private bool bEnableGodMode = false;


    void Awake()
    {
        GetPlayerUI = FindObjectOfType<PlayerUIController>();
        GetPlayerController = GetComponentInChildren<InputSystem_PlayerController>();
        GetPlayerState = GetComponentInChildren<PlayerStateScript>();
        pcStats = GetComponent<CharacterStats>();

        player = GetComponent<Player>();


    }



    private void OnDisable()
    {
        activateSpecialEvent.RemoveAllListeners();
        deactivateSpecialEvent.RemoveAllListeners();
        updateDataEvent.RemoveAllListeners();
        toggleGodModeEvent.RemoveAllListeners();
    }

    // Start is called before the first frame update
    void Start()
    {
        updateDataEvent.AddListener(GetPlayerUI.UpdateUIData);
        activateSpecialEvent.AddListener(ActivateSpecialAbility);
        deactivateSpecialEvent.AddListener(DeactivateSpecialAbilty);
        toggleGodModeEvent.AddListener(ToggleGodMode);

        modPowerEvent.AddListener(RecoverPower);
        if (Debug.isDebugBuild || Application.isEditor)
        {
            bIsDebug = true;
        }
        currentKeyboard = Keyboard.current;
        CurrentPower = MaxPower;

        PowerGaugePercentage = CurrentPower / MaxPower;
        playerHealthPercentage = pcStats.CurrentHealth / pcStats.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentKeyboard.slashKey.wasPressedThisFrame)
        {
            if (bIsDebug)
            {
                player.PlayerDamageTaken(10.0f);
            }
        }
        if (bStartPower)
        {
            StartCoroutine(ConsumePower());
        }
        else
        {
            StopCoroutine(ConsumePower());
        }
        if (bStartHealthRegen)
        {
            StartCoroutine(RegenHealth());
        }
        else
        {
            StopCoroutine(RegenHealth());
        }

    }




    public void ActivateSpecialAbility()
    {
        bStartPower = true;
        if (currentSpecialAbility == ESpecialAbility.SlowTime)
        {
            ActivateSlowTime();
        }
        if (currentSpecialAbility == ESpecialAbility.Aragon)
        {
            ActivateAragon();
        }
    }

    void ActivateSlowTime()
    {
        GetPlayerController.GetGameInstance.adjustTimeEvent.Invoke(SlowTimeAmount);
    }
    void DeactivateSlowTime()
    {
        GetPlayerController.GetGameInstance.adjustTimeEvent.Invoke(1.0f);
    }


    void ActivateAragon()
    {
        GetPlayerController.combatController.currentWeapon.SendMessage("ModifyDamage", DamageMultiplierAmount);
        //StartCoroutine(RegenHealth());
        bStartHealthRegen = true;
    }
    void DeactivateAragon()
    {
        GetPlayerController.combatController.currentWeapon.SendMessage("RevertDamage");
        //StartCoroutine(RegenHealth());
        bStartHealthRegen = false;
    }

    public IEnumerator RegenHealth()
    {
        pcStats.CurrentHealth += HealthRegenAmount;
        if (pcStats.CurrentHealth >= pcStats.MaxHealth)
        {
            pcStats.CurrentHealth = pcStats.MaxHealth;
        }
        yield return HealthRegenRate;
    }

    public void RecoverPower(float modAmount)
    {
        CurrentPower += modAmount;
        if (CurrentPower >= MaxPower)
        {
            CurrentPower = MaxPower;
        }
    }


    public IEnumerator ConsumePower()
    {
        CurrentPower -= PowerConsumeAmount;
        PowerGaugePercentage = CurrentPower / MaxPower;
        updateDataEvent.Invoke();
        yield return PowerConsumeRate;
        if (CurrentPower <= 0)
        {
            DeactivateSpecialAbilty();
        }
    }

    void DeactivateSpecialAbilty()
    {
        bStartPower = false;
        if (currentSpecialAbility == ESpecialAbility.SlowTime)
        {
            DeactivateSlowTime();
        }
        if (currentSpecialAbility == ESpecialAbility.Aragon)
        {
            DeactivateAragon();
        }
    }

    void ToggleGodMode()
    {
        bEnableGodMode = !bEnableGodMode;
        if (bEnableGodMode)
        {
            Debug.Log("God mode enabled");
            pcStats.bCanTakeDamage = false;
        }
        else
        {
            Debug.Log("God mode disabled");
            pcStats.bCanTakeDamage = false;
        }

    }

}
