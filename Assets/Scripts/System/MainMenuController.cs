using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private GameObject PlayerGO;
    private GameObject PlayerUIGO;
    private GameObject MusicPlayerGO;
    private GameObject GameManagerGO;
    private SaveManager saveManager;

    private ID_MainMenuCanvas MainMenu;
    public ID_OptionsMenu OptionsMenu;

    private SceneFadeTransition GetSceneFade;

    void Awake()
    {
       // Debug.Log(Application.persistentDataPath);
        GetSceneFade = FindObjectOfType<SceneFadeTransition>();
        GameManagerGO = FindObjectOfType<ID_GameManager>().gameObject;
        saveManager = FindObjectOfType<SaveManager>();
        MainMenu = FindObjectOfType<ID_MainMenuCanvas>();
        OptionsMenu = FindObjectOfType<ID_OptionsMenu>();
       // OptionsMenu.gameObject.SetActive(false);

        if(System.IO.File.Exists(Application.persistentDataPath + "/player.sav"))
        {
            Debug.Log("Save exists!");
        }
        else
        {
            Debug.Log("No save exists!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MusicPlayerGO = FindObjectOfType<BGM_Player>().gameObject;
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void StartNewGame()
    {
        Destroy(MusicPlayerGO);
        Destroy(GameManagerGO);
        GetSceneFade.FadeToNextLevel();
        //SceneManager.LoadScene("TestLevel");

    }

    public void ShowMainMenu()
    {
        OptionsMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }

    public void ShowOptionsMenu()
    {
        OptionsMenu.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }
    public void LeaveGame()
    {
        #if UNITY_STANDALONE
        Application.Quit();
        #endif

        #if UNITY_EDITOR

        if (Application.isEditor)
        {
            EditorApplication.isPlaying = false;
        }
        #endif
    }

    public void ContinueGame()
    {
        if (saveManager)
        {
            saveManager.LoadPlayerData();
        }

    }
}
