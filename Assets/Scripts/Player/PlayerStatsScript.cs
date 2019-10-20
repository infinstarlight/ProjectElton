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
    public CharacterStats pcStats;
    private Player player;
    public ESpecialAbility currentSpecialAbility;
    private int styleIndex = 0;

    private bool bIsDebug = false;

    void Awake()
    {
        pcStats = GetComponent<CharacterStats>();
        styleIndex = 1;
        //pcStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Offense;
        player = GetComponent<Player>();
        healthText = FindObjectOfType<HealthTextScript>();

    }

    // Start is called before the first frame update
    void Start()
    {
        // healthText = FindObjectOfType<HealthTextScript>();
        UpdateHealthText();
        //ModifyCurrentStyleUp();

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
            healthText.TextMesh.text = pcStats.CurrentHealth.ToString();
        }
    }

    public void ModifyCurrentStyleUp()
    {
        if (styleIndex <= 0)
        {
            styleIndex = 1;
        }
        if (styleIndex > 4)
        {
            styleIndex = 1;
        }
        Debug.Log(pcStats.currentCharacterStyle);
        // switch (pcStats.currentCharacterStyle)
        // {
        //     case CharacterStats.ECharacterStyle.Offense:
        //         {
        //             pcStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Defense;
        //             break;
        //         }
        //     case CharacterStats.ECharacterStyle.Defense:
        //         {
        //             pcStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Speed;
        //             break;
        //         }
        //     case CharacterStats.ECharacterStyle.Speed:
        //         {
        //             pcStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Regen;
        //             break;
        //         }
        //     case CharacterStats.ECharacterStyle.Regen:
        //         {
        //             pcStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Offense;
        //             break;
        //         }
        // }
        styleIndex++;
        switch (styleIndex)
        {
            case 1:
                // styleIndex = 1;
                pcStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Offense;
                break;
            case 2:
                // styleIndex = 2;
                pcStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Defense;
                break;
            case 3:
                //styleIndex = 3;
                pcStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Speed;
                break;
            case 4:
                //styleIndex = 4;
                pcStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Regen;
                break;
        }
    }

    public void ModifyCurrentStyleDown()
    {
        if (styleIndex <= 0)
        {
            styleIndex = 1;
        }
        styleIndex--;
        switch (styleIndex)
        {
            case 1:
                //styleIndex = 1;
                pcStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Offense;
                break;
            case 2:
                //styleIndex = 2;
                pcStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Defense;
                break;
            case 3:
                //styleIndex = 3;
                pcStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Speed;
                break;
            case 4:
                // styleIndex = 4;
                pcStats.currentCharacterStyle = CharacterStats.ECharacterStyle.Regen;
                break;
        }
    }

}
