using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
[RequireComponent(typeof(PlayerStatsScript))]
public class Player : Character
{
    public PlayerStatsScript PlayerStats;
    private AudioSource playerSource;
    public InputSystem_PlayerController pCon;

    public float StyleDamageMod = 2.5f;

    public static Player instance = null;

    public List<InventoryItem> ItemInventory = new List<InventoryItem>();
    public UnityEvent AddItemEvent = new UnityEvent();


    void OnEnable()
    {
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
    }

    void OnDisable()
    {
        damageEvent.RemoveAllListeners();
    }


    // Start is called before the first frame update
    void Start()
    {

        bShouldDestroyOnDeath = false;
        pCon = GetComponentInChildren<InputSystem_PlayerController>();
        playerSource = GetComponent<AudioSource>();
        PlayerStats = GetComponent<PlayerStatsScript>();

        PlayerStats.playerHealthPercentage = characterStats.CurrentHealth / characterStats.MaxHealth;
        PlayerStats.updateDataEvent.Invoke();

    }


    public void PlayerDamageTaken(float damageTaken)
    {
        base.OnDamageApplied(damageTaken);
        if (hurtClips.Length > 0)
        {
            playerSource.clip = hurtClips[Random.Range(0, hurtClips.Length)];
            playerSource.PlayOneShot(playerSource.clip);
        }
        PlayerStats.playerHealthPercentage = characterStats.CurrentHealth / characterStats.MaxHealth;
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

    public void AddItem(InventoryItem newItem)
    {
        ItemInventory.Add(newItem);
    }
}
