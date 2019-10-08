using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private GameObject PlayerGO;
    private GameObject PlayerUIGO;
    private GameObject MusicPlayerGO;
    // Start is called before the first frame update
    void Start()
    {
        MusicPlayerGO = FindObjectOfType<BGM_Player>().gameObject;
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (!PlayerGO)
        {
            PlayerGO = FindObjectOfType<Player>().gameObject;

        }
        if (!PlayerUIGO)
        {
            PlayerUIGO = FindObjectOfType<ID_PlayerUI>().gameObject;
        }

    }

    void Update()
    {

        if (PlayerGO)
        {
            Destroy(PlayerGO);
        }
        if (PlayerUIGO)
        {
            Destroy(PlayerUIGO);
        }
    }

    public void StartNewGame()
    {
        Destroy(MusicPlayerGO);
        SceneManager.LoadScene("TestLevel");
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
    }
    public void LeaveGame()
    {
        //#if UNITY_STANDALONE
        Application.Quit();
        //#endif

        // if(Application.isEditor)
        // {
        //     Application.isPlaying = false;
        // }
    }
}
