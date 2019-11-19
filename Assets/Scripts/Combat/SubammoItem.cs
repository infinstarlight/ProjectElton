using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubammoItem : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   private void OnTriggerEnter(Collider collision)
    {
        // Debug.Log("This item collided with " + collision.name);
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            if (CurrentItemType == ItemType.SubweaponAmmo)
            {
                RecoverAmmo();
            }

            Destroy(gameObject, 2f);
        }

    }
}
