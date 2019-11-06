using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private Player GetPlayer;
    public bool bWasSaveLoaded = false;

    void OnEnable()
    {
        GetPlayer = FindObjectOfType<Player>();
    }

    void Start()
    {
        GetPlayer = FindObjectOfType<Player>();
    }
    public void SavePlayerData()
    {
        if (GetPlayer)
        {
            SaveSystem.SavePlayer(GetPlayer);
        }

    }

    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayer();


        Vector3 savedPosition;
        string savedSceneName = data.lastSceneName;

        savedPosition.x = data.position[0];
        savedPosition.y = data.position[1];
        savedPosition.z = data.position[2];
        SceneManager.LoadScene(savedSceneName);
        if (!GetPlayer)
        {
            var PlayerGO = Resources.Load<GameObject>("Characters/Player/IS_PlayerCharacter") as GameObject;
            Instantiate(PlayerGO, transform.position, transform.rotation);
            var PlayerUIGO = Resources.Load<GameObject>("Characters/Player/PlayerUI") as GameObject;
            Instantiate(PlayerUIGO);
            GetPlayer = PlayerGO.GetComponent<Player>();

            GetPlayer.PlayerStats.pcStats.CurrentHealth = data.health;
            GetPlayer.gameObject.transform.position = savedPosition;
            GetPlayer.PlayerStats.UpdateHealthText();
            

        }
        if (GetPlayer)
        {
            GetPlayer.PlayerStats.pcStats.CurrentHealth = data.health;
            GetPlayer.gameObject.transform.position = savedPosition;
            GetPlayer.PlayerStats.UpdateHealthText();
            //SceneManager.LoadScene(savedSceneName);
        }

        bWasSaveLoaded = true;


    }

    //TODO: Function for finding most recent save
    //TODO: Create UI that lists 
}
