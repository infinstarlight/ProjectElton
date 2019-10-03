using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, ITracker
{
    public float StyleModAmount = 1.0f;
    private PlayerStateScript playerState;

    private AIControllerBase AIController;

    void EnemyAwake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerState = FindObjectOfType<PlayerStateScript>();
        AIController = GetComponentInChildren<AIControllerBase>();
    }

    private void Update()
    {
        if (!playerState)
        {
            playerState = FindObjectOfType<PlayerStateScript>();
        }
    }
    public void OnTrackTarget()
    {
        NavPoint playerNavPoint = FindObjectOfType<Player>().gameObject.GetComponentInChildren<NavPoint>();
        //AIController.myNavAgent.myNavPoints.Add(playerNavPoint);
    }

    public void OnEnemyDamageApplied(float damageTaken)
    {
        base.OnDamageApplied(damageTaken);
        if (characterStats.bCanTakeDamage)
        {
            //OnTrackTarget();
            AIEventManager.TriggerEvent("Damage");
            playerState.ModStyle(StyleModAmount);
            if(characterStats.CurrentHealth <= 0)
            {
                OnEnemyDeath();
            }
        }

    }

    public void OnEnemyDeath()
    {
        base.OnDeath();
        if (bShouldDestroyOnDeath)
        {
            Destroy(gameObject, DestroyDelay);
        }
    }
}
