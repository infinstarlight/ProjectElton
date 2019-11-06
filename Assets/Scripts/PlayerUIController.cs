using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private InputSystem_PlayerController pCon;
    private PlayerStatsScript statsScript;
    private GameObject PauseMenu;
    private GameObject CharMenu;
    private ID_StyleSlider styleSliderScript;
    private ID_PlayerHealthSlider healthbar;
    private Player GetPlayer;

    private void OnEnable()
    {
        GetPlayer = FindObjectOfType<Player>();
        pCon = FindObjectOfType<InputSystem_PlayerController>();
        styleSliderScript = FindObjectOfType<ID_StyleSlider>();
        CharMenu = FindObjectOfType<ID_CharMenu>().gameObject;
        healthbar = FindObjectOfType<ID_PlayerHealthSlider>();
        statsScript = FindObjectOfType<PlayerStatsScript>();

        // if (Time.timeScale <= 1)
        // {
        //     Time.timeScale = 1;
        // }

    }

    // Start is called before the first frame update
    void Start()
    {
       // CharMenu = pCon.CharMenuGO;
        PauseMenu = pCon.PauseMenuGO;
        if (PauseMenu)
        {
            PauseMenu.SetActive(false);
        }
        if(CharMenu)
        {
            CharMenu.SetActive(false);
        }

        
    }

    private void Update()
    {
        if (!styleSliderScript)
        {
            styleSliderScript = FindObjectOfType<ID_StyleSlider>();
        }
        //TODO: Maybe move this to SendMessage on enemy
        if (styleSliderScript != null)
        {
            styleSliderScript.styleSlider.value = pCon.playerState.StylePercent;
        }

        //TODO: Move this to UpdateHealthText function

        if (healthbar)
        {
            healthbar.healthSlider.value = pCon.playerStats.pcStats.healthPercentage;
        }


        // if (PauseMenu == null)
        // {
        //     PauseMenu = FindObjectOfType<ID_PauseMenu>().gameObject;
        // }
        // //  if (!CharMenu)
        // // {
        // //     CharMenu = FindObjectOfType<ID_CharMenu>().gameObject;

        // // }
    }

    public void UnpauseGame()
    {
        if (PauseMenu)
        {
            if (Time.timeScale <= 1)
            {
                Time.timeScale = 1;
            }
            if (PauseMenu.activeSelf)
            {
                pCon.bIsGamePaused = false;
                pCon.bEnableInput = true;
                PauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;

            }
        }
    }

    public void SaveCurrentProgress()
    {
        SaveSystem.SavePlayer(GetPlayer);
    }

    public void RestartFromCheckpoint()
    {
        Debug.LogWarning("We don't have save data so this will restart the scene for now");
        SaveSystem.LoadPlayer();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
