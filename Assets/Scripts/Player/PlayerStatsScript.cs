using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsScript : MonoBehaviour
{
    public enum ESpecialAbility
    {
        None,
        Dash,
        Regen,
        Booster,
    }
    private HealthTextScript healthText;
    private CharacterStats playerStats;
    private Player player;
    public ESpecialAbility currentSpecialAbility;
    private int styleIndex;

    private bool bIsDebug = false;

    void Awake()
    {
        playerStats = GetComponent<CharacterStats>();
        playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Standard;
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
        ModifyCurrentStyle();
//        Debug.Log(playerStats.currentCharacterStyle);
    }

    public void UpdateHealthText()
    {
        if (healthText)
        {
            healthText.TextMesh.text = playerStats.CurrentHealth.ToString();
        }
    }

    void ModifyCurrentStyle()
    {
        if (Input.GetButtonDown("Style Switch Up"))
        {
            styleIndex++;
            switch (styleIndex)
            {
                case 1:
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Offense;
                    break;
                case 2:
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Defense;
                    break;
                case 3:
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Speed;
                    break;
                case 4:
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Regen;
                    break;
                case 5:
                    styleIndex = 0;
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Offense;
                    break;
            }
        }

        if (Input.GetButtonDown("Style Switch Down"))
        {
            styleIndex--;
            switch (styleIndex)
            {
                case 1:
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Offense;
                    break;
                case 2:
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Defense;
                    break;
                case 3:
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Speed;
                    break;
                case 4:
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Regen;
                    break;
                case 5:
                    styleIndex = 0;
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Offense;
                    break;
            }
        }
        if (Input.GetAxisRaw("Style Switch") >= 0.75f)
        {
            styleIndex++;
            switch (styleIndex)
            {
                case 1:
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Offense;
                    break;
                case 2:
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Defense;
                    break;
                case 3:
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Speed;
                    break;
                case 4:
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Regen;
                    break;
                case 5:
                    styleIndex = 0;
                    playerStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Offense;
                    break;
            }
        }
    }

}
