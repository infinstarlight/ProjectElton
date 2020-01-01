using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuController : MonoBehaviour, IUIManager
{
    private GameObject PlayerGO;
    private GameObject PlayerUIGO;
    private GameObject MusicPlayerGO;
    private GameObject GameManagerGO;
    private GameInstance GetGameInstance;
    private SaveManager saveManager;

    private ID_MainMenuCanvas MainMenu;
    public ID_OptionsMenu OptionsMenu;

    private SceneFadeTransition GetSceneFade;
    public string LevelNameToLoad = "";

    void Awake()
    {
        GetSceneFade = FindObjectOfType<SceneFadeTransition>();
        GameManagerGO = FindObjectOfType<GameInstance>().gameObject;
        GetGameInstance = GameManagerGO.GetComponent<GameInstance>();
        saveManager = FindObjectOfType<SaveManager>();
        MainMenu = FindObjectOfType<ID_MainMenuCanvas>();
        OptionsMenu = FindObjectOfType<ID_OptionsMenu>();
        OptionsMenu.gameObject.SetActive(false);

        if (System.IO.File.Exists(Application.persistentDataPath + "/player.sav"))
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

    private void Update()
    {
        if (GetGameInstance.bIsReturningToMainMenu)
        {
            if (!PlayerGO)
            {
                PlayerGO = FindObjectOfType<Player>().gameObject;
                Destroy(PlayerGO);
                PlayerGO = null;
            }
            if (!PlayerUIGO)
            {
                PlayerGO = FindObjectOfType<ID_PlayerUI>().gameObject;
                Destroy(PlayerUIGO);
                PlayerUIGO = null;
            }
        }


    }

    public void SwitchCategory(GameObject targetGO)
    {

    }

    public void StartNewGame()
    {
        Destroy(MusicPlayerGO);
        //Destroy(GameManagerGO);
        GetSceneFade.FadeToLevelByString(LevelNameToLoad);
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

    public void SwitchMenu(GameObject currentMenu, GameObject newMenu)
    {
        if(currentMenu && newMenu)
        {
            if(currentMenu.activeSelf)
            {
                currentMenu.SetActive(false);
                newMenu.SetActive(true);
            }
            else
            {
                currentMenu.SetActive(true);
                newMenu.SetActive(false);
            }
        }
    } 
}
