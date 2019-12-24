using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private InputSystem_PlayerController pCon;
    private PlayerStatsScript statsScript;
    private GameObject PauseMenu;
    private GameObject CharMenu;
    private GameObject TouchControlGO;
    private ID_StyleSlider styleSliderScript;
    private ID_TouchUI GetTouchUI;

    private ID_PlayerHealthSlider healthBar;
    private ID_PlayerAragonSlider aragonBar;
    private ID_InteractText interactText;
    public bool bShowInteractText;
    private GameObject optionsMenu;
    private Player GetPlayer;

    private GameInstance GetGameInstance;
    private SaveManager GetSaveManager;
    private HealthTextScript healthText;
    public UnityEvent showInteractEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        GetGameInstance = FindObjectOfType<GameInstance>();
        GetTouchUI = FindObjectOfType<ID_TouchUI>();
        GetPlayer = FindObjectOfType<Player>();
        pCon = FindObjectOfType<InputSystem_PlayerController>();
        styleSliderScript = FindObjectOfType<ID_StyleSlider>();
        optionsMenu = FindObjectOfType<ID_OptionsMenu>().gameObject;
        showInteractEvent.AddListener(ToggleInteractText);
        healthBar = FindObjectOfType<ID_PlayerHealthSlider>();
        aragonBar = FindObjectOfType<ID_PlayerAragonSlider>();
        healthText = FindObjectOfType<HealthTextScript>();
        statsScript = FindObjectOfType<PlayerStatsScript>();
        interactText = FindObjectOfType<ID_InteractText>();
        TouchControlGO = GetTouchUI.gameObject;

        if (GetGameInstance)
        {
            GetSaveManager = GetGameInstance.gameObject.GetComponentInChildren<SaveManager>();
        }



        PauseMenu = pCon.PauseMenuGO;
        CharMenu = pCon.CharMenuGO;
        if (optionsMenu)
        {
            optionsMenu.SetActive(false);
        }


        if (TouchControlGO)
        {
            if (GetGameInstance.bIsRunningOnMobile)
            {
                TouchControlGO.SetActive(true);
            }
            else
            {
                TouchControlGO.SetActive(false);
            }
        }


    }


    private void Update()
    {
        if (!styleSliderScript)
        {
            styleSliderScript = FindObjectOfType<ID_StyleSlider>();
        }
        if (!GetGameInstance)
        {
            GetGameInstance = FindObjectOfType<GameInstance>();
            GetSaveManager = GetGameInstance.gameObject.GetComponentInChildren<SaveManager>();
        }
    }

    public void UpdateUIData()
    {
        //TODO: Maybe move this to SendMessage on enemy
        if (styleSliderScript)
        {
            styleSliderScript.styleSlider.value = pCon.playerState.StylePercent;
        }

        //TODO: Move this to UpdateHealthText function

        if (healthBar)
        {
            healthBar.healthSlider.value = pCon.playerStats.playerHealthPercentage;
        }
        if (healthText)
        {
            healthText.TextMesh.text = pCon.playerStats.pcStats.CurrentHealth.ToString();
        }
        if (aragonBar)
        {
            aragonBar.aragonSlider.value = pCon.playerStats.PowerGaugePercentage;
        }
    }

    public void ShowOptions()
    {
        if (Time.timeScale >= 1)
        {
            pCon.PauseGame();

        }
        // if (optionsMenu)
        // {
        //     if (!optionsMenu.activeSelf)
        //     {
        //         optionsMenu.SetActive(true);
        //     }
        // }

    }

    public void HideOptions()
    {
        // if (optionsMenu)
        // {
        //     if (optionsMenu.activeSelf)
        //     {
        //         optionsMenu.SetActive(false);
        //     }
        // }
        pCon.ShowMenu(PauseMenu);
    }

    public void UnpauseGame()
    {
        if (PauseMenu)
        {
            pCon.ShowMenu(PauseMenu);
        }
    }

    public void SaveCurrentProgress()
    {
        SaveSystem.SavePlayer(GetPlayer);
    }

    public void RestartFromCheckpoint()
    {
        Debug.LogWarning("We don't have save data so this will restart the scene for now");
        GetSaveManager.LoadPlayerData();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToggleInteractText()
    {
        if (interactText)
        {
            if (bShowInteractText)
            {
                interactText.myAnimator.SetBool("bShowText", true);
            }
            else
            {
                interactText.myAnimator.SetBool("bShowText", false);
            }
        }
    }

    public void OnPointerUpdate(InputAction.CallbackContext context)
    {
        var moveValue = context.ReadValue<Vector2>();
        // Debug.Log(moveValue);
    }
}
