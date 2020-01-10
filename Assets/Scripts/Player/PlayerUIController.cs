using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private InputSystem_PlayerControllerV2 pCon;
    private PlayerStatsScript statsScript;
    private GameObject PauseMenu;
    private GameObject CharMenu;
    private GameObject TouchControlGO;
    private ID_StyleSlider styleSliderScript;
    private ID_TouchUI GetTouchUI;

    private ID_PlayerHealthSlider healthBar;
    private AragonTextScript aragonText;
    private ID_PlayerAragonSlider aragonBar;
    private ID_InteractText interactText;
    public bool bShowInteractText;
    private GameObject optionsMenu;
    private GameObject moneyText;
    public float currentMoneyUI = 0.0f;
    private Player GetPlayer;

    private GameInstance GetGameInstance;
    private SaveManager GetSaveManager;
    private HealthTextScript healthText;
    public UnityEvent showInteractEvent = new UnityEvent();
    public UnityEvent showTouchUIEvent = new UnityEvent();

    private void OnDisable()
    {
        showTouchUIEvent.RemoveAllListeners();
        showInteractEvent.RemoveAllListeners();
    }

    // Start is called before the first frame update
    void Start()
    {

        GetGameInstance = FindObjectOfType<GameInstance>();
        GetTouchUI = GetComponentInChildren<ID_TouchUI>();
        GetPlayer = FindObjectOfType<Player>();
        pCon = GetPlayer.pCon;
        styleSliderScript = GetComponentInChildren<ID_StyleSlider>();
        optionsMenu = FindObjectOfType<ID_OptionsMenu>().gameObject;
        showInteractEvent.AddListener(ToggleInteractText);
        showTouchUIEvent.AddListener(ShowTouchUI);
        healthBar = GetComponentInChildren<ID_PlayerHealthSlider>();
        aragonBar = GetComponentInChildren<ID_PlayerAragonSlider>();
        healthText = GetComponentInChildren<HealthTextScript>();
        aragonText = GetComponentInChildren<AragonTextScript>();
        statsScript = GetComponentInChildren<PlayerStatsScript>();
        interactText = GetComponentInChildren<ID_InteractText>();
        moneyText = GetComponentInChildren<ID_PlayerMoney>().gameObject;
        TouchControlGO = GetTouchUI.gameObject;
        if (GetGameInstance)
        {
            GetSaveManager = GetGameInstance.gameObject.GetComponentInChildren<SaveManager>();
        }

        ShowTouchUI();

        PauseMenu = pCon.PauseMenuGO;
        CharMenu = pCon.CharMenuGO;
        if (optionsMenu)
        {
            optionsMenu.SetActive(false);
        }

        GetPlayer.PlayerStats.updateDataEvent.Invoke();
    }


    private void Update()
    {
        if (!styleSliderScript)
        {
            styleSliderScript = GetComponentInChildren<ID_StyleSlider>();
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
            healthBar.healthSlider.value = GetPlayer.PlayerStats.playerHealthPercentage;
        }
        if (healthText)
        {
            healthText.TextMesh.text = GetPlayer.PlayerStats.CurrentHealth.ToString();
        }
        if (aragonBar)
        {
            aragonBar.aragonSlider.value = GetPlayer.PlayerStats.PowerGaugePercentage;
        }
        if (aragonText)
        {
            aragonText.TextMesh.text = GetPlayer.PlayerStats.CurrentPower.ToString();
        }
        if (moneyText)
        {
            currentMoneyUI = pCon.GetPlayer.currentMoney;
            moneyText.GetComponent<ID_PlayerMoney>().textObject.text = currentMoneyUI.ToString();
        }
        // if (GetGameInstance.bIsRunningOnMobile)
        // {
        //     ShowTouchUI();
        // }


    }

    void ShowTouchUI()
    {
        if (GetGameInstance.bIsRunningOnMobile)
        {
            ToggleTouchUI(true);
        }
        else
        {
            ToggleTouchUI(false);
        }

    }

    void ToggleTouchUI(bool bEnable)
    {
        if (TouchControlGO)
        {
            if (bEnable)
            {
                TouchControlGO.SetActive(true);
                if (Mouse.current != null)
                {
                    Cursor.lockState = CursorLockMode.None;
                }

            }
            else
            {
                TouchControlGO.SetActive(false);
                if (Mouse.current != null)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
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
}
