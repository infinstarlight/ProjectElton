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
    public Gamepad currentGamepad;
    private Touchscreen currentTouchscreen;
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
    public Player GetPlayer;
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
        GetPlayer = GetComponentInParent<Player>();
        HUDGO = FindObjectOfType<ID_PlayerHUD>().gameObject;
        CharMenuGO = FindObjectOfType<ID_CharMenu>().gameObject;
        PauseMenuGO = FindObjectOfType<ID_PauseMenu>().gameObject;
        uiController = FindObjectOfType<PlayerUIController>();
        GetGameInstance = FindObjectOfType<GameInstance>();
        GetSaveManager = GetGameInstance.gameObject.GetComponentInChildren<SaveManager>();
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
        //EnhancedTouchSupport.Enable();

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
        if (CharMenuGO)
        {
            CharMenuGO.SetActive(false);
        }

    }

    void Update()
    {
        CheckForNewDevice();
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
                    if (device != null)
                    {
                        Debug.LogWarning("New device added: " + device);
                        InputSystem.AddDevice(device);
                        for (int i = 0; i < Gamepad.all.Count; ++i)
                        {
                            if (device == Gamepad.all.ToArray()[i])
                            {
                                currentGamepad = Gamepad.all.ToArray()[i];
                            }
                        }
                        //If on touchscreen and gamepad is connected
                        //Disable touch controls and use gamepad
                        //Do vice versa
                    }

                    break;
                case InputDeviceChange.Disconnected:
                    // Device got unplugged
                    Debug.LogWarning("Device is disconnected: " + device);
                    //InputSystem.Dis
                    break;
                case InputDeviceChange.Reconnected:
                    // Plugged back in
                    Debug.LogWarning("Device reconnected: " + device);
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
        if (!uiController)
        {
            uiController = FindObjectOfType<PlayerUIController>();
        }
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
        if (rbMovement)
        {
            myControls.Gameplay.Move.performed += rbMovement.OnMoveUpdate;
        }

        myControls.Gameplay.Pause.performed += OnGamePause;
        myControls.Gameplay.Interact.performed += OnInteractEvent;
        myControls.Gameplay.CharacterMenu.performed += OnCharMenu;
        myControls.Gameplay.Sprint.performed += rbMovement.OnSprint;
        myControls.Gameplay.Jump.performed += rbMovement.OnJump;
        myControls.Gameplay.Fire.performed += combatController.OnFire;
        myControls.Gameplay.Aim.performed += cameraLook.OnLockOn;
        myControls.Gameplay.Aim.canceled += cameraLook.OnLockOnStop;
        myControls.Gameplay.Dash.performed += rbMovement.OnSpecialAbility;
        myControls.Gameplay.SelectWeaponOne.performed += combatController.OnPrimaryWeaponSelect;
        myControls.Gameplay.SelectWeaponTwo.performed += combatController.OnSecondWeaponSelect;
        myControls.Gameplay.SelectWeaponThree.performed += combatController.OnThirdWeaponSelect;
        myControls.Gameplay.Zoom.performed += cameraLook.OnZoom;
        myControls.Gameplay.Look.performed += cameraLook.OnLook;
        myControls.Gameplay.SelectPreviousWeapon.performed += combatController.OnWeaponCycleDown;
        myControls.Gameplay.SelectNextWeapon.performed += combatController.OnWeaponCycleUp;
        myControls.Gameplay.ActivateSubweapon.performed += combatController.OnSubFire;
        myControls.Gameplay.SpecialAbility.performed += OnActivateSP;
        myControls.Gameplay.SpecialAbility.canceled += OnActivateSP;
        myControls.Gameplay.Enable();
        myControls.Gameplay.Pause.Enable();
        if (GetGameInstance.bIsRunningOnMobile)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        InputSystem.pollingFrequency = 120;

        myControls.Gameplay.Move.performed += context => LeftStickValue = context.ReadValue<Vector2>();
        myControls.Gameplay.Move.canceled += context => LeftStickValue = Vector2.zero;
        myControls.Gameplay.Look.performed += context => RightStickValue = context.ReadValue<Vector2>();
        myControls.Gameplay.Look.canceled += context => RightStickValue = Vector2.zero;
        myControls.Gameplay.Fire.performed += context => FireButtonValue = context.ReadValue<float>() > 0.5f;
        myControls.Gameplay.Fire.canceled += context => FireButtonValue = false;
        myControls.Gameplay.Jump.performed += context => JumpButtonValue = context.ReadValue<float>() > 0.1f;
        myControls.Gameplay.Jump.canceled += context => JumpButtonValue = false;

        if (currentKeyboard == null)
        {
            currentKeyboard = Keyboard.current;
        }
        if (currentGamepad == null && Gamepad.current != null)
        {
            currentGamepad = Gamepad.current;
        }
        if (currentTouchscreen == null)
        {
            currentTouchscreen = Touchscreen.current;
        }
        if (currentTouchscreen != null && currentGamepad == null)
        {
            uiController.showTouchUIEvent.Invoke();
        }
        if (currentGamepad != null && currentTouchscreen == null)
        {
            uiController.showTouchUIEvent.Invoke();
        }
    }

    void DisableGameControls()
    {
        bEnableGameInput = false;
        myControls.Gameplay.Disable();
        if (currentTouchscreen != null && currentGamepad == null)
        {
            uiController.showTouchUIEvent.Invoke();
        }
        if (currentGamepad != null && currentTouchscreen == null)
        {
            uiController.showTouchUIEvent.Invoke();
        }

    }

    void EnableUIControls()
    {
        myControls.UI.Enable();
        myControls.UI.Point.Enable();
        myControls.UI.Navigate.Enable();
        myControls.UI.Submit.Enable();
        myControls.UI.Cancel.Enable();
        myControls.UI.Click.Enable();
        myControls.UI.RightClick.Enable();
        myControls.UI.MiddleClick.Enable();
        myControls.UI.ScrollWheel.Enable();
    }

    void DisableUIControls()
    {
        myControls.UI.Disable();
        myControls.UI.Point.Disable();
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
