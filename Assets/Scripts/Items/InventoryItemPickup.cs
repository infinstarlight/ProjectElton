using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemPickup : MonoBehaviour
{
    public InventoryItem ItemToAdd;
    private Player myPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        myPlayer = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            if (myPlayer.gameObject)
            {
                myPlayer.SendMessage("AddItem", ItemToAdd);
                Destroy(gameObject,2f);
            }
        }
    }
}
