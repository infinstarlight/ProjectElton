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

    private void Awake()
    {
        pCon = FindObjectOfType<InputSystem_PlayerController>();
        styleSliderScript = FindObjectOfType<ID_StyleSlider>();
        healthbar = FindObjectOfType<ID_PlayerHealthSlider>();
        statsScript = FindObjectOfType<PlayerStatsScript>();

    }

    // Start is called before the first frame update
    void Start()
    {
        CharMenu = pCon.CharMenuGO;
        PauseMenu = pCon.PauseMenuGO;

        if (Time.timeScale <= 1)
        {
            Time.timeScale = 1;
        }

        if(PauseMenu)
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
        //TODO: Maybe move this to SendMessage on enemy
        if (styleSliderScript != null)
        {
            styleSliderScript.styleSlider.value = pCon.playerState.StylePercent;
        }

        //TODO: Move this to UpdateHealthText function
        {
            if(healthbar)
            {
                healthbar.healthSlider.value = pCon.playerStats.pcStats.healthPercentage;
            }
        }

        if (PauseMenu == null)
        {
            PauseMenu = FindObjectOfType<ID_PauseMenu>().gameObject;
        }
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
