using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public float StyleModAmount = 1.0f;
    public float PowerModAmount = 0.1f;
    private PlayerStateScript playerState;

    private AIControllerBase AIController;
    private AINavController GetAINav;
    public EnemyUIController enemyUIController;
    public GameObject dropMoneyGO;

    public GameObject AI_Weapon;
    private EnemyWeapon myWeapon;

    public GameObject[] itemsGO = new GameObject[2];
    private ID_EnemyHealthBar enemyHealthBar;
    public float MoneyToAdd = 15.0f;


    void EnemyAwake()
    {
        base.Awake();


    }
    // Start is called before the first frame update
    void Start()
    {
        itemsGO[0] = null;
        itemsGO[1] = null;
        enemyHealthBar = GetComponentInChildren<ID_EnemyHealthBar>();

        GetAINav = GetComponentInChildren<AINavController>();
        AIController = GetComponentInChildren<AIControllerBase>();
        enemyUIController = GetComponentInChildren<EnemyUIController>();
        //        playerNavPoint = FindObjectOfType<Player>().gameObject.GetComponentInChildren<NavPoint>();
        AI_Weapon = GetComponentInChildren<EnemyWeapon>().gameObject;
        myWeapon = AI_Weapon.GetComponent<EnemyWeapon>();
        damageEvent.AddListener(OnEnemyDamageApplied);
        var smallhealthGO = Resources.Load<GameObject>("Prefabs/Items/SmallHealthPickup") as GameObject;
        var smallammoGO = Resources.Load<GameObject>("Prefabs/Items/SmallAmmoPickup") as GameObject;

        itemsGO[0] = smallhealthGO;
        itemsGO[1] = smallammoGO;
        //damageEvent.AddListener(OnEnemyDamageApplied);

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

        }

    }


    public void OnEnemyDamageApplied(float damageTaken)
    {
        base.OnDamageApplied(damageTaken);
        if (characterStats.bCanTakeDamage)
        {
            GetAINav.trackPlayerEvent.Invoke();
            AIEventManager.TriggerEvent("Damage");
            enemyHealthBar.healthBar.value = characterStats.healthPercentage;
            playerState.styleModEvent.Invoke(StyleModAmount);
            if (characterStats.CurrentHealth <= 0)
            {
                OnEnemyDeath();
                SpawnRandomPickup();
            }
        }

    }

    public void OnEnemyDeath()
    {
        base.OnDeath();
        playerState.PlayerRef.ModMoneyEvent.Invoke(MoneyToAdd);
    }

    public void SpawnRandomPickup()
    {
        Instantiate(itemsGO[Random.Range(0, itemsGO.Length)], transform.position, transform.rotation);
        Destroy(gameObject, DestroyDelay);
    }
}
