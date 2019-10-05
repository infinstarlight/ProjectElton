using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : Item
{
    //public float ModAmount = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        CurrentItemType = ItemType.Health;
        itemSource = GetComponent<AudioSource>();
    }

    //Update is called once per frame
    private void Update()
    {
        if (!GetPlayer)
        {
            GetPlayer = FindObjectOfType<Player>();
        }
    }


    // void OnCollisionEnter(Collision collision)
    // {
    //     Debug.Log("This item collided with " + collision.gameObject.name);
    // }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("This item collided with " + collision.name);
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            if (CurrentItemType == ItemType.Health)
            {
                RecoverHealth();
            }

            Destroy(gameObject, 2f);
        }
    }
}
