using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsScript : MonoBehaviour
{
    private HealthTextScript healthText;
    private CharacterStats playerStats;
    private Player player;

    private bool bIsDebug = false;

    void Awake()
    {
        playerStats = GetComponent<CharacterStats>();
        player = GetComponent<Player>();
        //healthText = FindObjectOfType<HealthTextScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        healthText = FindObjectOfType<HealthTextScript>();
        UpdateHealthText();
        if (Debug.isDebugBuild || Application.isEditor)
        {
            bIsDebug = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            if (bIsDebug)
            {
                player.PlayerDamageTaken(10.0f);
            }
        }
    }

    public void UpdateHealthText()
    {
        if (healthText)
        {
            healthText.TextMesh.text = playerStats.CurrentHealth.ToString();
        }
    }

}
