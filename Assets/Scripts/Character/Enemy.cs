using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, ITracker
{
    public float StyleModAmount = 1.0f;
    private PlayerStateScript playerState;

    private AIControllerBase AIController;
    public EnemyUIController enemyUIController;
    private NavPoint playerNavPoint;
    public GameObject AI_Weapon;

    void EnemyAwake()
    {
        base.Awake();

    }
    // Start is called before the first frame update
    void Start()
    {
        playerState = FindObjectOfType<PlayerStateScript>();
        AIController = GetComponentInChildren<AIControllerBase>();
        enemyUIController = GetComponentInChildren<EnemyUIController>();
        playerNavPoint = FindObjectOfType<Player>().gameObject.GetComponentInChildren<NavPoint>();

    }

    private void Update()
    {
        if (!playerState)
        {
            playerState = FindObjectOfType<PlayerStateScript>();
        }
        if(AIController.bIsPlayerVisible)
        {
            //Attempt to attack
            if(AI_Weapon)
            {
                AI_Weapon.GetComponent<Weapon>().AIFire();
            }
        }
    }
    public void OnTrackTarget()
    {
        AIController.myNavAgent.bIsTrackingPlayer = true;
        AIController.myNavAgent.myNavPoints.Add(playerNavPoint);
        AIController.myNavMeshAgent.SetDestination(playerNavPoint.transform.position);

    }

    public void OnEnemyDamageApplied(float damageTaken)
    {
        base.OnDamageApplied(damageTaken);
        if (characterStats.bCanTakeDamage)
        {
            OnTrackTarget();
            AIEventManager.TriggerEvent("Damage");
            playerState.ModStyle(StyleModAmount);
            if (characterStats.CurrentHealth <= 0)
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
