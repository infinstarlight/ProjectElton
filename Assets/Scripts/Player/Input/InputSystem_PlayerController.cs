using UnityEngine.Events;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using Popcron.Console;
using DG.Tweening;
using UnityEngine;


public class InputSystem_PlayerController : MonoBehaviour
{

    /// <summary>
    /// Retrieve current state of left stick.
    /// </summary>
    public Vector2 LeftStickValue { get; private set; }

    /// <summary>
    /// Retrieve current state of right stick.
    /// </summary>
    public Vector2 RightStickValue { get; private set; }

    /// <summary>
    /// Retrieve state of fire button.
    /// </summary>
    public bool FireButtonValue { get; private set; }

    /// <summary>
    /// Retrieve state of Jump button.
    /// </summary>
    public bool JumpButtonValue { get; private set; }

    public InputSystem_RigidbodyCharacterMovement rbMovement;
    public InputSystem_CameraLook cameraLook;
    public InputSystem_PlayerCombatController combatController;
    private GameInputControls myControls;
    public PlayerStateScript playerState;
    public bool bIsGamePaused = false;
    public bool bShowPauseMenu = false;
    public bool bEnableGameInput = true;
    public GameObject PauseMenuGO;
    public GameObject CharMenuGO;
    public GameObject HUDGO;
    private Camera playerCamera;
    public PlayerStatsScript playerStats;
    private Keyboard currentKeyboard;
    private Gamepad currentGamepad;
    private SaveManager GetSaveManager;
    public GameInstance GetGameInstance;
    public AudioClip[] interactSounds;
    private AudioSource source;
    [SerializeField]
    private bool bIsDebug = false;
    [SerializeField]
    private float InteractRange = 200.0f;
    private RaycastHit hit;
    private PlayerUIController uiController;
    public UnityEvent EnableGameInputEvent = new UnityEvent();
    public UnityEvent DisableGameInputEvent = new UnityEvent();
    public UnityEvent EnableUIInputEvent = new UnityEvent();
    public UnityEvent DisableUIInputEvent = new UnityEvent();
    public UnityEvent PauseGameEvent = new UnityEvent();
    private bool bActivateSpecial = false;
    public InputAction ToggleMouseStateAction;
    private bool bEnable;
    private PlayerInput GetPlayerInput;
    private Sequence satSequence;

    [Alias("gm")]
    [Command("GodMode")]
    public static void GodMode()
    {
        PlayerStatsScript.toggleGodModeEvent.Invoke();
    }

    void ToggleMouseState(InputAction.CallbackContext context)
    {
        if (bIsDebug)
        {
            bEnable = !bEnable;
            if (bEnable)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }

    void Awake()
    {
        EnableGameControls();
        bEnableGameInput = true;
        bShowPauseMenu = false;
        HUDGO = FindObjectOfType<ID_PlayerUI>().gameObject;
        CharMenuGO = FindObjectOfType<ID_CharMenu>().gameObject;
        PauseMenuGO = FindObjectOfType<ID_PauseMenu>().gameObject;
        uiController = FindObjectOfType<PlayerUIController>();
        GetSaveManager = FindObjectOfType<SaveManager>();
        source = GetComponent<AudioSource>();
        playerCamera = Camera.main;
        if (Application.isEditor || Debug.isDebugBuild)
        {
            bIsDebug = true;
        }
        else
        {
            bIsDebug = false;
        }
        ToggleMouseStateAction.performed += ToggleMouseState;
        EnhancedTouchSupport.Enable();

    }


    private void OnEnable()
    {
        Parser.Register(this, "player");
        EnableUIControls();
        ToggleMouseStateAction.Enable();
    }

    void OnDisable()
    {
        DisableGameControls();
        EnableGameInputEvent.RemoveAllListeners();
        DisableGameInputEvent.RemoveAllListeners();
        EnableUIInputEvent.RemoveAllListeners();
        DisableUIInputEvent.RemoveAllListeners();
        PauseGameEvent.RemoveAllListeners();
        ToggleMouseStateAction.Disable();
        Parser.Unregister(this);
    }



    void Start()
    {
        EnableGameInputEvent.AddListener(EnableGameControls);
        DisableGameInputEvent.AddListener(DisableGameControls);
        EnableUIInputEvent.AddListener(EnableUIControls);
        DisableUIInputEvent.AddListener(DisableUIControls);
        PauseGameEvent.AddListener(PauseGame);

        currentKeyboard = Keyboard.current;
        satSequence = DOTween.Sequence();
        if (PauseMenuGO)
        {
            PauseMenuGO.SetActive(false);
        }
        if(CharMenuGO)
        {
            CharMenuGO.SetActive(false);
        }
    }

    void Update()
    {
        var activeTouches = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches;
        for (var i = 0; i < activeTouches.Count; ++i)
        {
            Debug.Log("Active touch: " + activeTouches[i]);
        }

    }
    private void FixedUpdate()
    {
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
        GameObject hitObject = null;
        // actual Ray
        Ray ray = playerCamera.ViewportPointToRay(rayOrigin);

        if (Physics.Raycast(ray, out hit, InteractRange))
        {
            if (hit.collider)
            {
                hitObject = hit.collider.gameObject;
                if (hitObject.GetComponent<IInteractable>() != null)
                {
                    uiController.bShowInteractText = true;
                    uiController.showInteractEvent.Invoke();
                }
                else
                {
                    uiController.bShowInteractText = false;
                    uiController.showInteractEvent.Invoke();
                }
            }

        }
    }


    void CheckForNewDevice()
    {
        InputSystem.onDeviceChange +=
        (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    // New Device
                    //Debug.LogWarning("New device added: " + device);
                    InputSystem.AddDevice(device);
                    break;
                case InputDeviceChange.Disconnected:
                    // Device got unplugged
                    //Debug.LogWarning("Device is disconnected: " + device);
                    //InputSystem.Dis
                    break;
                case InputDeviceChange.Reconnected:
                    // Plugged back in
                    //Debug.LogWarning("Device reconnected: " + device);
                    break;
                case InputDeviceChange.Removed:
                    // Remove from Input System entirely; by default, devices stay in the system once discovered
                    //Debug.LogWarning("Device removed: " + device);
                    InputSystem.RemoveDevice(device);
                    break;
                default:
                    // See InputDeviceChange reference for other event types.
                    break;
            }
        };
    }

    void EnableGameControls()
    {
        GetGameInstance = FindObjectOfType<GameInstance>();
        if (!playerStats)
        {
            playerStats = GetComponentInParent<PlayerStatsScript>();
        }
        if (!playerState)
        {
            playerState = GetComponentInChildren<PlayerStateScript>();
        }

        if (!rbMovement)
        {
            rbMovement = GetComponentInParent<InputSystem_RigidbodyCharacterMovement>();
        }
        if (!cameraLook)
        {
            cameraLook = GetComponentInChildren<InputSystem_CameraLook>();
        }
        if (!combatController)
        {
            combatController = GetComponent<InputSystem_PlayerCombatController>();
        }

        if (myControls == null)
        {
            myControls = new GameInputControls();
        }
        bEnableGameInput = true;
        myControls.gameplay.Move.performed += rbMovement.OnMoveUpdate;
        myControls.gameplay.Pause.performed += OnGamePause;
        myControls.gameplay.Interact.performed += OnInteractEvent;
        myControls.gameplay.CharacterMenu.performed += OnCharMenu;
        myControls.gameplay.Sprint.performed += rbMovement.OnSprint;
        myControls.gameplay.Jump.performed += rbMovement.OnJump;
        myControls.gameplay.Fire.performed += combatController.OnFire;
        myControls.gameplay.Aim.performed += cameraLook.OnLockOn;
        myControls.gameplay.Aim.canceled += cameraLook.OnLockOnStop;
        myControls.gameplay.Dash.performed += rbMovement.OnSpecialAbility;
        myControls.gameplay.SelectWeaponOne.performed += combatController.OnPrimaryWeaponSelect;
        myControls.gameplay.SelectWeaponTwo.performed += combatController.OnSecondWeaponSelect;
        myControls.gameplay.SelectWeaponThree.performed += combatController.OnThirdWeaponSelect;
        myControls.gameplay.Zoom.performed += cameraLook.OnZoom;
        myControls.gameplay.Look.performed += cameraLook.OnLook;
        myControls.gameplay.SelectPreviousWeapon.performed += combatController.OnWeaponCycleDown;
        myControls.gameplay.SelectNextWeapon.performed += combatController.OnWeaponCycleUp;
        myControls.gameplay.ActivateSubweapon.performed += combatController.OnSubFire;
        myControls.gameplay.SpecialAbility.performed += OnActivateSP;
        myControls.gameplay.SpecialAbility.canceled += OnActivateSP;
        myControls.gameplay.Enable();
        myControls.gameplay.Pause.Enable();
        Cursor.lockState = CursorLockMode.Locked;

        InputSystem.pollingFrequency = 120;

        myControls.gameplay.Move.performed += context => LeftStickValue = context.ReadValue<Vector2>();
        myControls.gameplay.Move.canceled += context => LeftStickValue = Vector2.zero;
        myControls.gameplay.Look.performed += context => RightStickValue = context.ReadValue<Vector2>();
        myControls.gameplay.Look.canceled += context => RightStickValue = Vector2.zero;
        myControls.gameplay.Fire.performed += context => FireButtonValue = context.ReadValue<float>() > 0.5f;
        myControls.gameplay.Fire.canceled += context => FireButtonValue = false;
        myControls.gameplay.Jump.performed += context => JumpButtonValue = context.ReadValue<float>() > 0.1f;
        myControls.gameplay.Jump.canceled += context => JumpButtonValue = false;


    }

    void DisableGameControls()
    {
        bEnableGameInput = false;
        myControls.gameplay.Disable();

    }

    void EnableUIControls()
    {
        myControls.ui.Enable();
        myControls.ui.Point.Enable();
        myControls.ui.Navigate.Enable();
        myControls.ui.Submit.Enable();
        myControls.ui.Cancel.Enable();
        myControls.ui.Click.Enable();
        myControls.ui.RightClick.Enable();
        myControls.ui.MiddleClick.Enable();
        myControls.ui.ScrollWheel.Enable();
    }

    void DisableUIControls()
    {
        myControls.ui.Disable();
        myControls.ui.Point.Disable();
        EnableGameControls();
    }

    public void OnGamePause(InputAction.CallbackContext context)
    {
        ShowMenu(PauseMenuGO);
    }

    public void OnCharMenu(InputAction.CallbackContext context)
    {
        ShowMenu(CharMenuGO);
    }

    public void OnInteractEvent(InputAction.CallbackContext context)
    {
        Interact();
    }

    public void OnActivateSP(InputAction.CallbackContext context)
    {

        ActivateSpecial();
    }

    public void OnActivateSupport(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                {
                    cameraLook.OnScanActivate();
                }

                break;

            case InputActionPhase.Started:
                {
                  
                }
                break;
            case InputActionPhase.Canceled:
                {
                  
                }
                break;
        }
    }

    void ToggleSpecial()
    {
        bActivateSpecial = !bActivateSpecial;
    }

    void ActivateSpecial()
    {
        ToggleSpecial();
        if (!bActivateSpecial)
        {
            playerStats.deactivateSpecialEvent.Invoke();

        }
        if (bActivateSpecial)
        {
            playerStats.activateSpecialEvent.Invoke();

        }
    }


    public void PauseGame()
    {
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        bIsGamePaused = !bIsGamePaused;
        if (bIsGamePaused)
        {
            EnableUIControls();
            GetGameInstance.adjustTimeEvent.Invoke(0.0f);


        }
        else
        {
            if (!GetGameInstance.bIsRunningOnMobile)
            {
                DisableUIControls();
            }

            GetGameInstance.adjustTimeEvent.Invoke(1.0f);
        }
    }

    public void ShowMenu(GameObject menuGO)
    {
        Cursor.lockState = CursorLockMode.None;
        PauseGame();
        if (menuGO)
        {
            if (!menuGO.activeSelf)
            {
                HUDGO.SetActive(false);
                menuGO.SetActive(true);
            }
            else
            {
                HUDGO.SetActive(true);
                menuGO.SetActive(false);
            }
        }
    }

    void Interact()
    {
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen

        GameObject hitObject = null;
        // actual Ray
        Ray ray = playerCamera.ViewportPointToRay(rayOrigin);
        // debug Ray
        Debug.DrawRay(ray.origin, ray.direction * InteractRange, Color.red);

        if (Physics.Raycast(ray, out hit, InteractRange))
        {
            if (hit.collider)
            {
                hitObject = hit.collider.gameObject;
                if (hitObject.GetComponent<IInteractable>() != null)
                {
                    hitObject.GetComponent<IInteractable>().OnInteract();
                    source.PlayOneShot(interactSounds[1]);
                }
                else
                {
                    source.PlayOneShot(interactSounds[0]);
                }
            }

        }
    }



}
