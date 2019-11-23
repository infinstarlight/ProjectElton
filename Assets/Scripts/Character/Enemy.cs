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
    private EnemyWeapon myWeapon;

    public GameObject[] itemsGO = new GameObject[2];


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
        AI_Weapon = GetComponentInChildren<EnemyWeapon>().gameObject;
        myWeapon = AI_Weapon.GetComponent<EnemyWeapon>();
        damageEvent.AddListener(OnEnemyDamageApplied);
        var smallhealthGO = Resources.Load<GameObject>("Prefabs/Items/SmallHealthPickup") as GameObject;
        var smallammoGO = Resources.Load<GameObject>("Prefabs/Items/SmallAmmoPickup") as GameObject;
        itemsGO[0] = smallhealthGO;
        itemsGO[1] = smallammoGO;

    }

    private void Update()
    {
        if (!playerState)
        {
            playerState = FindObjectOfType<PlayerStateScript>();
        }
        if (AIController)
        {
            if (AIController.bIsPlayerVisible)
            {
                //Attempt to attack
                if (AI_Weapon)
                {
                    AI_Weapon.GetComponent<EnemyWeapon>().StartCoroutine(AI_Weapon.GetComponent<EnemyWeapon>().AIFire());
                }
            }
            else
            {
                if (AIController.bIsHumanoid)
                {
                    if (AIController.myNavAgent.myNavPoints.Contains(playerNavPoint))
                    {
                        AIController.myNavAgent.myNavPoints.Remove(playerNavPoint);
                    }
                }

            }
        }

    }
    public void OnTrackTarget()
    {
        if (AIController)
        {
            AIController.myNavAgent.bIsTrackingPlayer = true;
            AIController.myNavAgent.myNavPoints.Add(playerNavPoint);
            AIController.myNavMeshAgent.SetDestination(playerNavPoint.transform.position);
        }


    }

    public void OnEnemyDamageApplied(float damageTaken)
    {
        base.OnDamageApplied(damageTaken);
        if (characterStats.bCanTakeDamage)
        {
            OnTrackTarget();
            AIEventManager.TriggerEvent("Damage");

            playerState.styleModEvent.Invoke(StyleModAmount);
            if (characterStats.CurrentHealth <= 0)
            {
                OnEnemyDeath();
            }
        }

    }

    public void OnEnemyDeath()
    {
        base.OnDeath();
        SpawnRandomPickup();
        Destroy(gameObject, DestroyDelay);
        if (bShouldDestroyOnDeath)
        {

        }
    }

    public void SpawnRandomPickup()
    {
        Instantiate(itemsGO[Random.Range(0, itemsGO.Length)], transform.position, transform.rotation);
    }
}
