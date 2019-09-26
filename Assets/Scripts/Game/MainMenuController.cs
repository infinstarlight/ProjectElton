using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("Demo_LevelTest");
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
