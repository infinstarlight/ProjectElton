using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private PlayerController pCon;
    private GameObject PauseMenu;
    private ID_StyleSlider styleSliderScript;

    // Start is called before the first frame update
    void Start()
    {
        pCon = FindObjectOfType<PlayerController>();
        styleSliderScript = FindObjectOfType<ID_StyleSlider>();
        //PauseMenu = pCon.PauseMenuGO;
        
        if(Time.timeScale <= 1)
        {
            Time.timeScale = 1;
        }
    }

    private void Update()
    {
        if (styleSliderScript != null)
        {
            styleSliderScript.styleSlider.value = pCon.playerState.StylePercent;
        }
       
    //    if(PauseMenu == null)
    //    {
    //        PauseMenu = FindObjectOfType<ID_PauseMenu>().gameObject;
    //    }
    }

    // public void UnpauseGame()
    // {
    //     if (PauseMenu)
    //     {
    //         if(Time.timeScale <= 1)
    //     {
    //         Time.timeScale = 1;
    //     }
    //         if (PauseMenu.activeSelf)
    //         {
    //             pCon.bIsGamePaused = false;
    //             pCon.bEnableInput = true;
    //             PauseMenu.SetActive(false);
    //             Cursor.lockState = CursorLockMode.Locked;
                
    //         }
    //     }
    // }

    public void RestartFromCheckpoint()
    {
        Debug.LogWarning("We don't have save data so this will restart the scene for now");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
