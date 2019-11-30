using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    private GameObject interactText;
    private bool bShowInteractText;
    private GameObject optionsMenu;
    private Player GetPlayer;
    public UnityEvent updateUIEvent = new UnityEvent();
    private GameInstance GetGameInstance;
    private SaveManager GetSaveManager;
   // private HealthTextScript healthText;


    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        GetPlayer = FindObjectOfType<Player>();
        pCon = FindObjectOfType<InputSystem_PlayerController>();
        styleSliderScript = FindObjectOfType<ID_StyleSlider>();
        optionsMenu = FindObjectOfType<ID_OptionsMenu>().gameObject;
        CharMenu = FindObjectOfType<ID_CharMenu>().gameObject;
        healthBar = FindObjectOfType<ID_PlayerHealthSlider>();
        aragonBar = FindObjectOfType<ID_PlayerAragonSlider>();
        statsScript = FindObjectOfType<PlayerStatsScript>();
        interactText = FindObjectOfType<ID_InteractText>().gameObject;
        GetTouchUI = FindObjectOfType<ID_TouchUI>();
        TouchControlGO = GetTouchUI.gameObject;
        GetGameInstance = FindObjectOfType<GameInstance>();
        GetSaveManager = GetGameInstance.gameObject.GetComponentInChildren<SaveManager>();
        if (GetGameInstance.bIsRunningOnMobile)
        {
            TouchControlGO.SetActive(true);
        }
        else
        {
            TouchControlGO.SetActive(false);
        }
        updateUIEvent.AddListener(UpdateUIData);
        PauseMenu = pCon.PauseMenuGO;
        if (PauseMenu)
        {
            PauseMenu.SetActive(false);
        }
        if (CharMenu)
        {
            CharMenu.SetActive(false);
        }
        if (optionsMenu)
        {
            optionsMenu.SetActive(false);
        }
        if (interactText)
        {
            interactText.SetActive(false);
        }
        if (healthBar)
        {
            UpdateUIData();
        }
    }

    public void UpdateUIData()
    {
        //TODO: Maybe move this to SendMessage on enemy
        if (styleSliderScript != null)
        {
            styleSliderScript.styleSlider.value = pCon.playerState.StylePercent;
        }

        //TODO: Move this to UpdateHealthText function

        if (healthBar)
        {
            healthBar.healthSlider.value = pCon.playerStats.playerHealthPercentage;
        }
        // if (healthText)
        // {
        //     healthText.TextMesh.text = pCon.playerStats.pcStats.CurrentHealth.ToString();
        // }
        if(aragonBar)
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
        if (optionsMenu)
        {
            if (!optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(true);
            }
        }

    }

    public void HideOptions()
    {
        if (optionsMenu)
        {
            if (optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(false);
            }
        }
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
        bShowInteractText = !bShowInteractText;
        if (interactText)
        {
            if (bShowInteractText)
            {
                interactText.GetComponent<Animator>().SetBool("bShowText",bShowInteractText);
            }
            else
            {
                interactText.GetComponent<Animator>().SetBool("bShowText",bShowInteractText);
            }
        }
    }
}
