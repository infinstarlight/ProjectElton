using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameInstance : MonoBehaviour
{

    private PlayerConfig GetPlayerConfig;
    private Player GetPlayer;
    private ID_PlayerUI playerUI;

    void Awake()
    {
        if (Time.timeScale <= 0)
        {
            Time.timeScale = 1;
        }
        GetPlayerConfig = GetComponentInChildren<PlayerConfig>();
        GetPlayer = FindObjectOfType<Player>();
        playerUI = FindObjectOfType<ID_PlayerUI>();
    }


    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        //Debug.Log(mode);
        if(scene.name != "MainMenu")
        {
            GetPlayerConfig.gameObject.SetActive(false);
        }
    }

    // called third
    void Start()
    {
     //   Debug.Log("Start");
    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}


