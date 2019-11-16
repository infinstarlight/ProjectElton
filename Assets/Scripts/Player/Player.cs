using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
[RequireComponent(typeof(PlayerStatsScript))]
public class Player : Character
{
    public PlayerStatsScript PlayerStats;


    private GameObject playerUI;
    private AudioSource playerSource;
    private PlayerStateScript playerState;
    public InputSystem_PlayerController pCon;

    public float StyleDamageMod = 2.5f;

    public static Player instance = null;


   

    void OnEnable()
    {
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
        damageEvent.AddListener(PlayerDamageTaken);
    }

    void OnDisable()
    {

    }

    void PlayerAwake()
    {
        // playerSource = GetComponent<AudioSource>();
        // PlayerStats = GetComponent<PlayerStatsScript>();

    }

    // Start is called before the first frame update
    void Start()
    {


        bShouldDestroyOnDeath = false;
        pCon = GetComponentInChildren<InputSystem_PlayerController>();
        playerState = GetComponentInChildren<PlayerStateScript>();
        playerSource = GetComponent<AudioSource>();
        PlayerStats = GetComponent<PlayerStatsScript>();

        PlayerStats.UpdateHealthText();
        playerUI = FindObjectOfType<ID_PlayerUI>().gameObject;

    }


    public void PlayerDamageTaken(float damageTaken)
    {
        if (characterStats.bCanTakeDamage)
        {
            characterStats.CurrentHealth -= damageTaken;
            playerSource.clip = hurtClips[Random.Range(0, hurtClips.Length)];
            playerSource.PlayOneShot(playerSource.clip);
            if (characterStats.CurrentHealth <= 0)
            {
                characterStats.bIsDead = true;
                OnPlayerDeath();
            }
        }
        PlayerStats.UpdateHealthText();
        playerState.playerDamageStyleEvent.Invoke(StyleDamageMod);
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
}
