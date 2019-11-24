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

    void OnEnable()
    {
        //   GetPlayer = FindObjectOfType<Player>();
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
            audioSource.PlayOneShot(audioSource.clip);
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

    //TODO: Function for finding most recent save
    //TODO: Create UI that lists 
}
