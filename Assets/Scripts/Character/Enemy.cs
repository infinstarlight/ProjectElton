using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character 
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    
   public void OnEnemyDamageApplied(float damageTaken)
    {
        base.OnDamageApplied(damageTaken);
        AIEventManager.TriggerEvent("Damage");
    }
}
