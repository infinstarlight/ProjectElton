using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Health,
        DKAmmo,
        PowerUp
    }
    public float RecoverAmount = 0;
    private Player GetPlayer;
    public AudioSource itemSource;

    public ItemType CurrentItemType;

    private void Start()
    {

        GetPlayer = FindObjectOfType<Player>();
        itemSource = GetComponent<AudioSource>();
    }

    public void RecoverHealth()
    {
        GetPlayer.characterStats.ModifyHealth(RecoverAmount);
    }


   
}
