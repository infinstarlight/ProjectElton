using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ID_EnemyHealthBar : MonoBehaviour
{
    protected Slider healthBar;
    private CharacterStats enemyStats;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        
        enemyStats = FindObjectOfType<Enemy>().characterStats;
        enemyStats.CharacterName = enemyStats.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        // if (enemyStats == null)
        // {
        //     enemyStats = FindObjectOfType<Character>().characterStats;
        // }
        if (enemyStats != null)
        {
            healthBar.value = enemyStats.healthPercentage;
            
        }

    }
}
