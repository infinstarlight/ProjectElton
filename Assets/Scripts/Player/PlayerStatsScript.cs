using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsScript : MonoBehaviour
{
    private HealthTextScript healthText;
    private CharacterStats playerStats;
    private Player player;

    void Awake()
    {
        playerStats = GetComponent<CharacterStats>();
        player = GetComponent<Player>();
        healthText = FindObjectOfType<HealthTextScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       public void UpdateHealthText()
    {
        healthText.TextMesh.text = playerStats.CurrentHealth.ToString();
    }

    // public void UpdateAmmoText()
    // {
    //     DK_AmmoText.TextMesh.text = playerDreamkiss.CurrentAmmo.ToString();
    // }
}
