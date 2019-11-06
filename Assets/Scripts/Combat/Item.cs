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
    public Player GetPlayer;
    public AudioSource itemSource;

    public ItemType CurrentItemType;

    void Start()
    {
        GetPlayer = FindObjectOfType<Player>();
        itemSource = GetComponent<AudioSource>();
    }

   

    public void RecoverHealth()
    {
        GetPlayer.characterStats.ModifyHealth(RecoverAmount);
        GetPlayer.PlayerStats.UpdateHealthText();
        itemSource.PlayOneShot(itemSource.clip);
    }

    //Update is called once per frame
   


   
}
