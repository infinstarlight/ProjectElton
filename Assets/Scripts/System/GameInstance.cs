﻿using DG.Tweening;
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
        SceneManager.LoadScene(newScene, LoadSceneMode.Single);
    }



}

public class GameInstance : MonoBehaviour
{

    private static GameInstance instance = null;
    public static GameInstance Instance { get { return instance; } }
    private PlayerConfig GetPlayerConfig;
    private Player GetPlayer;
    private ID_PlayerUI playerUI;
    public bool bIsReturningToMainMenu = false;
    public bool bIsRunningOnMobile = false;
    private static BGM_Player GetBGMPlayer;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);

        if (Time.timeScale <= 0)
        {
            Time.timeScale = 1;
        }
        //GetPlayerConfig = GetComponentInChildren<PlayerConfig>();
        GetPlayer = FindObjectOfType<Player>();
        playerUI = FindObjectOfType<ID_PlayerUI>();
        GetBGMPlayer = FindObjectOfType<BGM_Player>();
        Console.Initialize();
        DOTween.Init();
    }


    // called first
    void OnEnable()
    {
        //        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
        GetBGMPlayer = FindObjectOfType<BGM_Player>();
        Parser.Register(this, "instance");
        Console.Open = false;
#if UNITY_STANDALONE
        bIsRunningOnMobile = false;

#endif
#if UNITY_XBOXONE
          bIsRunningOnMobile = false;
#endif
#if UNITY_IOS || UNITY_ANDROID
        bIsRunningOnMobile = true;

#endif
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);

        if (scene.name != "MainMenu")
        {
            GetPlayer = FindObjectOfType<Player>();
            playerUI = FindObjectOfType<ID_PlayerUI>();
            if (GetPlayer && playerUI)
            {
                //                Debug.Log("Player and HUD found!");
            }
            if (bIsReturningToMainMenu)
            {
                bIsReturningToMainMenu = false;
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

    // called when the game is terminated
    void OnDisable()
    {
        // Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Parser.Unregister(this);
    }


    [Alias("mm")]
    [Command("MuteMusic")]
    public void ToggleMusicMuteStatus()
    {
        if (!GetBGMPlayer.bShouldMute)
        {
            GetBGMPlayer.StartCoroutine(BGM_Player.FadeOut(GetBGMPlayer.source, 1.0f));
            GetBGMPlayer.bShouldMute = true;
        }
        else
        {
            GetBGMPlayer.StartCoroutine(BGM_Player.FadeIn(GetBGMPlayer.source, 1.0f));
            GetBGMPlayer.bShouldMute = false;
        }

    }
}


