using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Item : MonoBehaviour
{
    public enum ItemType
    {
        HealthPickup,
        SubweaponAmmo,
        PowerUp,
        HealthUpgrade,
        SubweaponAmmoUpgrade
    }
    public float ValueMod = 0;
    public Player GetPlayer;
    public AudioSource itemSource;

    public ItemType CurrentItemType;

    public void Awake()
    {
        GetPlayer = FindObjectOfType<Player>();
        itemSource = GetComponent<AudioSource>();
    }




    public void RecoverHealth()
    {
        if (CurrentItemType == ItemType.HealthPickup)
        {
            GetPlayer.SendMessage("HealCharacter", ValueMod);
            //GetPlayer.characterStats.HealCharacter(RecoverAmount);
            GetPlayer.PlayerStats.SendMessage("UpdateHealthText");
            //GetPlayer.PlayerStats.UpdateHealthText();
            itemSource.PlayOneShot(itemSource.clip);
        }

    }

    public void RecoverAmmo()
    {
        if (CurrentItemType == ItemType.SubweaponAmmo)
        {
            GetPlayer.pCon.combatController.currentSubWeapon.SendMessage("ModifyAmmo", ValueMod);
            itemSource.PlayOneShot(itemSource.clip);
        }
    }

    public void UpgradeHealth()
    {
        if (CurrentItemType == ItemType.HealthUpgrade)
        {
            GetPlayer.SendMessage("ModifyHealth", ValueMod);
            GetPlayer.PlayerStats.SendMessage("UpdateHealthText");
            //SaveSystem.SavePlayer(GetPlayer);
            SaveManager.SavePlayerData();
        }
    }



}
