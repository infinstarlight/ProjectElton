using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private Player GetPlayer;

    void OnEnable()
    {
        GetPlayer = FindObjectOfType<Player>();
    }
    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(GetPlayer);
    }

    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        GetPlayer.PlayerStats.pcStats.CurrentHealth = data.health;
        Vector3 savedPosition;
        savedPosition.x = data.position[0];
        savedPosition.y = data.position[1];
        savedPosition.z = data.position[2];
        GetPlayer.gameObject.transform.position = savedPosition;
        GetPlayer.PlayerStats.UpdateHealthText();

    }
}
