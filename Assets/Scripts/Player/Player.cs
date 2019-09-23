using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerStatsScript))]
public class Player : Character
{
    private PlayerStatsScript PlayerStats;
    private GameObject playerUI;

    void Awake()
    {
        PlayerStats = GetComponent<PlayerStatsScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.UpdateHealthText();
        playerUI = FindObjectOfType<ID_PlayerUI>().gameObject;
        if(playerUI == null)
        {
        var StatGO = Resources.Load<GameObject>("Prefabs/Debug/StatsMonitor") as GameObject;
        Instantiate(StatGO);
        playerUI = StatGO;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDamageTaken(float damageTaken)
    {
        base.OnDamageApplied(damageTaken);
        PlayerStats.UpdateHealthText();
        // if (PlayerStats.playerStats.bIsDead)
        // {
        //     animExplosive.gameObject.SetActive(true);
        // }
    }

    public void OnPlayerDeath()
    {
        base.OnDeath();
      
        
    }
}
