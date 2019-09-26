using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public float StyleModAmount = 1.0f;
    private PlayerStateScript playerState;

    void EnemyAwake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerState = FindObjectOfType<PlayerStateScript>();
    }

    // private void Update() 
    // {

    // }


    public void OnEnemyDamageApplied(float damageTaken)
    {
        base.OnDamageApplied(damageTaken);
        if (characterStats.bCanTakeDamage)
        {
            AIEventManager.TriggerEvent("Damage");
            playerState.ModStyle(StyleModAmount);
        }

    }
}
