using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static Player GetPlayer;
    public bool bWasSaveLoaded = false;
    private static AudioSource audioSource;
    private SceneFadeTransition GetFadeTransition;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        GetFadeTransition = FindObjectOfType<SceneFadeTransition>();
        GetPlayer = FindObjectOfType<Player>();
    }
    public static void SavePlayerData()
    {
        if (GetPlayer)
        {
            SaveSystem.SavePlayer(GetPlayer);
            if (audioSource)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }

        }

    }

    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayer();


        Vector3 savedPosition;
        string savedSceneName = data.lastSceneName;
        DateTime savedDT = data.GetDateTime;

        savedPosition.x = data.position[0];
        savedPosition.y = data.position[1];
        savedPosition.z = data.position[2];
        GetFadeTransition.bIsAlternateLoad = true;
        GetFadeTransition.FadeToLevelByString(savedSceneName);
        Debug.Log(savedDT);
        if (GetPlayer)
        {
            GetPlayer.PlayerStats.pcStats.CurrentHealth = data.health;
            GetPlayer.gameObject.transform.position = savedPosition;
            GetPlayer.PlayerStats.UpdateHealthText();

        }

        bWasSaveLoaded = true;


    }

    public static void LoadPlayerPosition()
    {
        PlayerData locData = SaveSystem.LoadPlayer();
        Vector3 savedLoc = new Vector3();
        savedLoc.x = locData.position[0];
        savedLoc.y = locData.position[1];
        savedLoc.z = locData.position[2];
        GetPlayer.gameObject.transform.position = savedLoc;

    }

    //TODO: Function for finding most recent save
    //TODO: Create UI that lists 
}
