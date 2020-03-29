using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
[RequireComponent(typeof(PlayerStatsScript))]
public class Player : Character
{
    public PlayerStatsScript PlayerStats;
    private AudioSource playerSource;
    public InputSystem_PlayerControllerV2 pCon;

    public float StyleDamageMod = 2.5f;
    public float currentMoney = 0;


    public static Player instance = null;

    public List<InventoryItem> ItemInventory = new List<InventoryItem>();
    public UnityEvent AddItemEvent = new UnityEvent();
    public UnityFloatEvent HealPlayerEvent = new UnityFloatEvent();
    public UnityFloatEvent RecoverPowerEvent = new UnityFloatEvent();
    public UnityFloatEvent ModHealthEvent = new UnityFloatEvent();
    public UnityFloatEvent ModMoneyEvent = new UnityFloatEvent();


    void OnEnable()
    {
        pCon = GetComponentInChildren<InputSystem_PlayerControllerV2>();
        playerSource = GetComponent<AudioSource>();
        PlayerStats = GetComponent<PlayerStatsScript>();

        if (instance == null)
        {
            instance = this; // In first scene, make us the singleton.
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
        }
        damageEvent.AddListener(PlayerDamageTaken);
        RecoverPowerEvent.AddListener(PlayerStats.RecoverPower);
        ModMoneyEvent.AddListener(ModMoney);
        ModHealthEvent.AddListener(PlayerStats.ModifyHealth);
        HealPlayerEvent.AddListener(PlayerStats.HealCharacter);
    }

    void OnDisable()
    {
        damageEvent.RemoveAllListeners();
        HealPlayerEvent.RemoveAllListeners();
        RecoverPowerEvent.RemoveAllListeners();
        ModHealthEvent.RemoveAllListeners();
    }


    // Start is called before the first frame update
    void Start()
    {
        bShouldDestroyOnDeath = false;
        PlayerStats.healthPercentage = characterStats.CurrentHealth / characterStats.MaxHealth;
    }


    public void PlayerDamageTaken(float damageTaken)
    {
        base.OnDamageApplied(damageTaken);
        if (hurtClips.Length > 0)
        {
            playerSource.clip = hurtClips[Random.Range(0, hurtClips.Length)];
            playerSource.PlayOneShot(playerSource.clip);
        }
        PlayerStats.healthPercentage = characterStats.CurrentHealth / characterStats.MaxHealth;
        PlayerStats.updateDataEvent.Invoke();
        pCon.playerState.playerDamageStyleEvent.Invoke(StyleDamageMod);
    }

    public void OnPlayerDeath()
    {
        if (characterStats.bIsDead)
        {
            pCon.bEnableGameInput = false;
            characterStats.bCanTakeDamage = false;
            playerSource.clip = deathClip;
            playerSource.PlayOneShot(playerSource.clip);

            //GameObject deathVX = Instantiate(DeathVFX, transform.position, transform.rotation);
        }


    }

    public void ModMoney(float modValue)
    {
        currentMoney += modValue;
        PlayerStats.updateDataEvent.Invoke();
    }

    public void AddItem(InventoryItem newItem)
    {
        ItemInventory.Add(newItem);
    }
}
