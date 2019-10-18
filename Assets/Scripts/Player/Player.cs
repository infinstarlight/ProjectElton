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
    private PlayerController pCon;

    public float StyleDamageMod = 2.5f;

    private static Player instance = null;
    public static Player Instance { get { return instance; } }

    // void Awake()
    // {
    //     //source = GetComponent<AudioSource>();
    //     //PlayerStats = GetComponent<PlayerStatsScript>();
    // }

    // Start is called before the first frame update
    void Start()
    {
        bShouldDestroyOnDeath = false;
        pCon = GetComponentInChildren<PlayerController>();
        playerState = GetComponentInChildren<PlayerStateScript>();
        playerSource = GetComponent<AudioSource>();
        PlayerStats = GetComponent<PlayerStatsScript>();
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

        }
        PlayerStats.UpdateHealthText();
        // playerUI = FindObjectOfType<ID_PlayerUI>().gameObject;
        // if (playerUI == null)
        // {
        //     var StatGO = Resources.Load<GameObject>("Prefabs/Debug/StatsMonitor") as GameObject;
        //     Instantiate(StatGO);
        //     playerUI = StatGO;
        // }

    }

    // // Update is called once per frame
    // void Update()
    // {

    // }

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
        playerState.PlayerStyleDamageMod(StyleDamageMod);
    }

    public void OnPlayerDeath()
    {
        if (characterStats.bIsDead)
        {
            pCon.bEnableInput = false;
            characterStats.bCanTakeDamage = false;
            playerSource.clip = deathClip;
            playerSource.PlayOneShot(playerSource.clip);

            //GameObject deathVX = Instantiate(DeathVFX, transform.position, transform.rotation);
        }


    }
}
