using System.Collections;
using System.Collections.Generic;
using Popcron.Console;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MyConsoleCommands
{
    [Alias("rl")]
    [Command("RestartLevel")]
    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    [Alias("lnl")]
    [Command("LoadNextLevel")]
    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    [Alias("ll")]
    [Command("LoadLevel")]
    public static void LoadThisLevel(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
}

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
        //GetPlayerConfig = GetComponentInChildren<PlayerConfig>();
        GetPlayer = FindObjectOfType<Player>();
        playerUI = FindObjectOfType<ID_PlayerUI>();
    }


    // called first
    void OnEnable()
    {
//        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
        Parser.Register(this,"instance");
        Console.Open = false;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);

        if (scene.name != "MainMenu")
        {
            GetPlayer = FindObjectOfType<Player>();
            playerUI = FindObjectOfType<ID_PlayerUI>();
            if(GetPlayer && playerUI)
            {
                Debug.Log("Player and HUD found!");
            }
           // GetPlayerConfig.gameObject.SetActive(false);
        }
        else
        {
            if (GetPlayer && playerUI)
            {
                Destroy(GetPlayer.gameObject);
                Destroy(playerUI.gameObject);
                //Debug.Log("Player and HUD removed!");
            }
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
       // Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Parser.Unregister(this);
    }

    


}


