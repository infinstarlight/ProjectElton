using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private InputSystem_PlayerControllerV2 pCon;
    private GameObject PauseMenu;
    private GameObject CharMenu;
    private GameObject TouchControlGO;
    private ID_MapScreen GetMapScreen;
    private ID_InventoryScreen GetInventoryScreen;
    private ID_TrishScreen GetTrishScreen;
    private ID_StatsScreen GetStatsScreen;
    private ID_AbilitiesScreen GetAbilitiesScreen;
    private ID_StyleSlider styleSliderScript;
    private ID_TouchUI GetTouchUI;

    private ID_PlayerHealthSlider healthBar;
    private AragonTextScript aragonText;
    private ID_PlayerAragonSlider aragonBar;
    private ID_InteractText interactText;
    public bool bShowInteractText;
    private GameObject optionsMenu;
    private ID_PlayerMoney moneyText;
    public float currentMoneyUI = 0.0f;
    private Player GetPlayer;
    private PlayerStateScript GetPlayerState;

    private GameInstance GetGameInstance;
    private SaveManager GetSaveManager;
    private HealthTextScript healthText;
    public UnityEvent showInteractEvent = new UnityEvent();
    public UnityEvent showTouchUIEvent = new UnityEvent();

    private void Awake()
    {
        GetPlayer = FindObjectOfType<Player>();
        pCon = GetPlayer.pCon;
        GetPlayerState = FindObjectOfType<PlayerStateScript>();
        PauseMenu = FindObjectOfType<ID_PauseMenu>().gameObject;
        CharMenu = FindObjectOfType<ID_CharMenu>().gameObject;
        GetMapScreen = CharMenu.GetComponentInChildren<ID_MapScreen>();
        GetInventoryScreen = CharMenu.GetComponentInChildren<ID_InventoryScreen>();
        GetTrishScreen = CharMenu.GetComponentInChildren<ID_TrishScreen>();
        GetStatsScreen = CharMenu.GetComponentInChildren<ID_StatsScreen>();
        GetAbilitiesScreen = CharMenu.GetComponentInChildren<ID_AbilitiesScreen>();
    }

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

        styleSliderScript = GetComponentInChildren<ID_StyleSlider>();
        optionsMenu = FindObjectOfType<ID_OptionsMenu>().gameObject;
        showInteractEvent.AddListener(ToggleInteractText);
        showTouchUIEvent.AddListener(ShowTouchUI);
        healthBar = GetComponentInChildren<ID_PlayerHealthSlider>();
        aragonBar = GetComponentInChildren<ID_PlayerAragonSlider>();
        healthText = GetComponentInChildren<HealthTextScript>();
        aragonText = GetComponentInChildren<AragonTextScript>();
        interactText = GetComponentInChildren<ID_InteractText>();
        moneyText = GetComponentInChildren<ID_PlayerMoney>();
        TouchControlGO = GetTouchUI.gameObject;
        if (GetGameInstance)
        {
            GetSaveManager = GetGameInstance.gameObject.GetComponentInChildren<SaveManager>();
        }

        ShowTouchUI();


        if (CharMenu)
        {
            CharMenu.SetActive(false);
        }
        if (PauseMenu)
        {
            PauseMenu.SetActive(false);
        }
        if (optionsMenu)
        {
            optionsMenu.SetActive(false);
        }

        UpdateUIData();
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
        styleSliderScript.styleSlider.value = GetPlayerState.StylePercent;
        healthBar.healthSlider.value = GetPlayer.PlayerStats.healthPercentage;
        healthText.TextMesh.text = GetPlayer.PlayerStats.CurrentHealth.ToString();
        aragonBar.aragonSlider.value = GetPlayer.PlayerStats.PowerGaugePercentage;
        aragonText.TextMesh.text = GetPlayer.PlayerStats.CurrentPower.ToString();
        currentMoneyUI = GetPlayer.currentMoney;
        moneyText.textObject.text = currentMoneyUI.ToString();
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
            pCon.PauseGame(true);

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
