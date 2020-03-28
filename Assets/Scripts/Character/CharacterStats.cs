using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    [Header("Character Health")]
    public float CurrentHealth;
    public float MaxHealth = 100;
    public float healthPercentage = 0.0f;

    [Header("Damage & Death")]
    public bool bIsDead = false;
    public bool bCanTakeDamage = true;

    [Header("Special Info")]

    public string CharacterName;

    public void Awake()
    {
        CurrentHealth = MaxHealth;

    }
    // Start is called before the first frame update
    void Start()
    {

    }



    public void HealCharacter(float ModAmount)
    {
        if (CurrentHealth != MaxHealth)
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
