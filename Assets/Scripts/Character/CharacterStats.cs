using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public enum ECharacterStyle
    {
        Standard = 0,
        Offense = 1,
        Defense = 2,
        Speed = 3,
        Regen = 4,
        Special = 5
    }
    [Header("Character Health")]
    public float CurrentHealth;
    public float MaxHealth = 100;
    public float healthPercentage = 0.0f;

    [Header("Damage & Death")]
    public bool bIsDead = false;
    public bool bCanTakeDamage = true;

    [Header("Special Info")]
    public ECharacterStyle currentCharacterStyle;

    public string CharacterName;

    void Awake()
    {
        CurrentHealth = MaxHealth;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthPercentage = CurrentHealth / MaxHealth;
        //Debug.Log(healthPercentage + "of: " + gameObject.name);
    }

    public void HealCharacter(float ModAmount)
    {
        if (CurrentHealth < MaxHealth)
        {
            CurrentHealth += ModAmount;
        }
        else
        {
            CurrentHealth = MaxHealth;
        }

    }

    public void ModifyHealth(float ModAmount)
    {
        MaxHealth += ModAmount;
        CurrentHealth = MaxHealth;
    }
    
}
