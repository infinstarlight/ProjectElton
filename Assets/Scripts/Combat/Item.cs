using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Health,
        DKAmmo,
        PowerUp
    }
    public int RecoverAmount = 0;
    private Player GetPlayer;

    public ItemType CurrentItemType;

    private void Start()
    {
        GetPlayer = FindObjectOfType<Player>();
    }

    public void RecoverHealth()
    {
        GetPlayer.characterStats.ModifyHealth(RecoverAmount);
    }


   
}
