using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Item : MonoBehaviour
{
    public enum ItemType
    {
        HealthPickup,
        AragonPickup,
        SubweaponAmmo,
        PowerUp,
        HealthUpgrade,
        SubweaponAmmoUpgrade,
        MoneyPickup
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


    public void ActivateItem()
    {
        switch (CurrentItemType)
        {
            case ItemType.HealthPickup:
                RecoverHealth();
                break;
            case ItemType.AragonPickup:
                RecoverAragon();
                break;
            case ItemType.SubweaponAmmo:
                RecoverAmmo();
                break;
            case ItemType.PowerUp:
                break;
            case ItemType.HealthUpgrade:
                break;
            case ItemType.SubweaponAmmoUpgrade:
                break;
            case ItemType.MoneyPickup:
                ModifyMoney();
                break;
            default:
                
                break;
        }
    }

    public void RecoverHealth()
    {
        if (CurrentItemType == ItemType.HealthPickup)
        {
            GetPlayer.HealPlayerEvent.Invoke(ValueMod);
            GetPlayer.PlayerStats.updateDataEvent.Invoke();
            itemSource.PlayOneShot(itemSource.clip);
            Destroy(gameObject,1f);
        }

    }

    public void RecoverAragon()
    {
        if (CurrentItemType == ItemType.AragonPickup)
        {
            GetPlayer.RecoverPowerEvent.Invoke(ValueMod);
            GetPlayer.PlayerStats.updateDataEvent.Invoke();
            itemSource.PlayOneShot(itemSource.clip);
            Destroy(gameObject, 1f);
        }
    }

    public void RecoverAmmo()
    {
        if (CurrentItemType == ItemType.SubweaponAmmo)
        {
            GetPlayer.pCon.combatController.currentSubWeaponGO.SendMessage("ModifyAmmo", ValueMod);
            itemSource.PlayOneShot(itemSource.clip);
            Destroy(gameObject, 1f);
        }
    }

    public void UpgradeHealth()
    {
        if (CurrentItemType == ItemType.HealthUpgrade)
        {
            GetPlayer.ModHealthEvent.Invoke(ValueMod);
            GetPlayer.PlayerStats.updateDataEvent.Invoke();
            SaveManager.SavePlayerData();
            Destroy(gameObject, 1f);
        }
    }

    public void ModifyMoney()
    {
        if (CurrentItemType == ItemType.MoneyPickup)
        {
            GetPlayer.ModMoneyEvent.Invoke((int)ValueMod);
            GetPlayer.PlayerStats.updateDataEvent.Invoke();
            Destroy(gameObject, 1f);
        }
    }



}
