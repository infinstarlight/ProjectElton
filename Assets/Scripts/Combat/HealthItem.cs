using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : Item
{
    // Start is called before the first frame update
    void Start()
    {
        CurrentItemType = ItemType.Health;

    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }


     void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("This item collided with " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("This item collided with " + collision.name);
        if(collision.gameObject.GetComponentInChildren<Player>() != null)
        {
            if(CurrentItemType == ItemType.Health)
            {
                RecoverHealth();
            }
            
            Destroy(gameObject);
        }
    }
}
