using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ID_EnemyHealthBar : MonoBehaviour
{
    public Slider healthBar;
    private CharacterStats enemyStats;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        
        enemyStats = GetComponentInParent<Enemy>().characterStats;
//        enemyStats.CharacterName = enemyStats.gameObject.name;
    }

  
}
