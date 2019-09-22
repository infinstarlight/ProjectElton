using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth = 100;
    public bool bIsDead = false;

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
        
    }
}
