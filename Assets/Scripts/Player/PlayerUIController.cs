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
        GetTouchUI = FindObjectOfType<ID_TouchUI>();
        GetPlayer = FindObjectOfType<Player>();
        //pCon = FindObjectOfType<InputSystem_PlayerController>();
        pCon = FindObjectOfType<InputSystem_PlayerControllerV2>();
        styleSliderScript = FindObjectOfType<ID_StyleSlider>();
        optionsMenu = FindObjectOfType<ID_OptionsMenu>().gameObject;
        showInteractEvent.AddListener(ToggleInteractText);
        showTouchUIEvent.AddListener(ShowTouchUI);
        healthBar = FindObjectOfType<ID_PlayerHealthSlider>();
        aragonBar = FindObjectOfType<ID_PlayerAragonSlider>();
        healthText = FindObjectOfType<HealthTextScript>();
        statsScript = FindObjectOfType<PlayerStatsScript>();
        interactText = FindObjectOfType<ID_InteractText>();
        moneyText = FindObjectOfType<ID_PlayerMoney>().gameObject;
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
        if (moneyText)
        {
            currentMoneyUI = pCon.GetPlayer.currentMoney;
            moneyText.GetComponent<ID_PlayerMoney>().textObject.text = currentMoneyUI.ToString();
        }
        ShowTouchUI();

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

        if (bEnable)
        {
            TouchControlGO.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            TouchControlGO.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
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
