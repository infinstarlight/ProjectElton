﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public enum ECharacterStyle
    {
        Standard,
        Offense,
        Defense,
        Speed,
        Regen
    }
    public float CurrentHealth;
    public float MaxHealth = 100;
    public bool bIsDead = false;
    public bool bCanTakeDamage = true;

    public float healthPercentage;
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

     public void ModifyHealth(float ModAmount)
    {
        CurrentHealth += ModAmount;
    }
}
