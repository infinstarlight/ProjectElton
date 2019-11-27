using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : Item
{

    // Start is called before the first frame update
    void Start()
    {
        CurrentItemType = ItemType.HealthUpgrade;
        itemSource = GetComponent<AudioSource>();
    }

   private void OnTriggerEnter(Collider collision)
    {
        // Debug.Log("This item collided with " + collision.name);
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            if(!GetPlayer)
            {
                GetPlayer = collision.gameObject.GetComponent<Player>();
            }
            if (CurrentItemType == ItemType.HealthUpgrade)
            {
                UpgradeHealth();
            }

            Destroy(gameObject);
        }

    }
}
