using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputSystem_PlayerController : MonoBehaviour
{

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
    private GameInstance GetGameInstance;
    public AudioClip[] interactSounds;
    private AudioSource source;
    [SerializeField]
    private bool bIsDebug = false;
    private bool bIsMouseReleased = false;
    [SerializeField]
    private float InteractRange = 200.0f;
    private RaycastHit hit;
    private PlayerUIController uiController;
    

    void OnDisable()
    {
        DisableGameControls();
    }

    void Awake()
    {
        EnableGameControls();
        bEnableGameInput = true;
        bShowPauseMenu = false;
        HUDGO = FindObjectOfType<ID_PlayerHUD>().gameObject;
        CharMenuGO = FindObjectOfType<ID_CharMenu>().gameObject;
        PauseMenuGO = FindObjectOfType<ID_PauseMenu>().gameObject;
        uiController = FindObjectOfType<PlayerUIController>();
        GetGameInstance = FindObjectOfType<GameInstance>();
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
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {

        PauseMenuGO.SetActive(false);
        GetSaveManager = FindObjectOfType<SaveManager>();
        currentKeyboard = Keyboard.current;
        currentGamepad = Gamepad.current;
    }
    // Update is called once per frame
    void Update()
    {
        if (!PauseMenuGO)
        {
            PauseMenuGO = FindObjectOfType<ID_PauseMenu>().gameObject;
        }
        if (bIsDebug)
        {
            if (currentKeyboard.f8Key.wasPressedThisFrame)
            {
                if (!bIsMouseReleased)
                {
                    Cursor.lockState = CursorLockMode.None;
                    bIsMouseReleased = true;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    bIsMouseReleased = false;
                }
                if (currentKeyboard.digit9Key.wasPressedThisFrame)
                {
                    SaveManager.SavePlayerData();
                }
                if (currentKeyboard.digit0Key.wasPressedThisFrame)
                {
                    GetSaveManager.LoadPlayerData();
                }

            }
        }
        // CheckForNewDevice();

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
                    uiController.ToggleInteractText();
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


        myControls.gameplay.Move.performed += rbMovement.OnMoveUpdate;
        bEnableGameInput = true;
        myControls.gameplay.Pause.performed += OnGamePause;
        myControls.gameplay.Interact.performed += OnInteractEvent;
        myControls.gameplay.CharacterMenu.performed += OnCharMenu;
        myControls.gameplay.MoveRight.performed += rbMovement.OnMoveRight;
        myControls.gameplay.MoveUp.performed += rbMovement.OnMoveUp;
        myControls.gameplay.Sprint.performed += rbMovement.OnSprint;
        myControls.gameplay.Jump.performed += rbMovement.OnJump;
        myControls.gameplay.Fire.performed += combatController.OnFire;
        myControls.gameplay.AltFire.performed += cameraLook.OnLockOn;
        myControls.gameplay.AltFire.canceled += cameraLook.OnLockOnStop;
        myControls.gameplay.SpecialAbility.performed += rbMovement.OnSpecialAbility;
        myControls.gameplay.StyleSwitchUp.performed += combatController.OnStyleSwitchUp;
        myControls.gameplay.StyleSwitchDown.performed += combatController.OnStyleSwitchDown;
        myControls.gameplay.SelectWeaponOne.performed += combatController.OnPrimaryWeaponSelect;
        myControls.gameplay.SelectWeaponTwo.performed += combatController.OnSecondWeaponSelect;
        myControls.gameplay.SelectWeaponThree.performed += combatController.OnThirdWeaponSelect;
        myControls.gameplay.Zoom.performed += cameraLook.OnZoom;
        myControls.gameplay.Look.performed += cameraLook.OnLook;
        myControls.gameplay.SelectPreviousWeapon.performed += combatController.OnWeaponCycleDown;
        myControls.gameplay.SelectNextWeapon.performed += combatController.OnWeaponCycleUp;
        myControls.gameplay.SelectNextWeapon.Enable();
        myControls.gameplay.SelectPreviousWeapon.Enable();
        myControls.gameplay.Interact.Enable();
        myControls.gameplay.Fire.Enable();
        myControls.gameplay.Look.Enable();
        myControls.gameplay.Pause.Enable();
        myControls.gameplay.CharacterMenu.Enable();
        myControls.gameplay.AltFire.Enable();
        myControls.gameplay.SelectWeaponOne.Enable();
        myControls.gameplay.SelectWeaponTwo.Enable();
        myControls.gameplay.SelectWeaponThree.Enable();
        myControls.gameplay.SpecialAbility.Enable();
        myControls.gameplay.Sprint.Enable();
        myControls.gameplay.Jump.Enable();
        myControls.gameplay.MoveRight.Enable();
        myControls.gameplay.MoveUp.Enable();
        myControls.gameplay.StyleSwitchUp.Enable();
        myControls.gameplay.StyleSwitchDown.Enable();
        myControls.gameplay.Move.Enable();
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Time.timeScale <= 1)
        {
            Time.timeScale = 1;
        }

    }

    void DisableGameControls()
    {
        bEnableGameInput = false;
        myControls.gameplay.Interact.Disable();
        // myControls.gameplay.Disable();
        myControls.gameplay.Fire.Disable();
        myControls.gameplay.Look.Disable();
        // myControls.gameplay.Pause.Disable();
        myControls.gameplay.CharacterMenu.Disable();
        myControls.gameplay.AltFire.Disable();
        myControls.gameplay.SelectWeaponOne.Disable();
        myControls.gameplay.SelectWeaponTwo.Disable();
        myControls.gameplay.SelectWeaponThree.Disable();
        myControls.gameplay.SpecialAbility.Disable();
        myControls.gameplay.Sprint.Disable();
        myControls.gameplay.Jump.Disable();
        myControls.gameplay.MoveRight.Disable();
        myControls.gameplay.MoveUp.Disable();
        myControls.gameplay.StyleSwitchUp.Disable();
        myControls.gameplay.StyleSwitchDown.Disable();
        myControls.gameplay.SelectNextWeapon.Disable();
        myControls.gameplay.SelectPreviousWeapon.Disable();
        myControls.gameplay.Move.Disable();
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Time.timeScale >= 1)
        {
            Time.timeScale = 0;
        }
    }

    void EnableUIControls()
    {
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        DisableGameControls();

        myControls.ui.Enable();
    }

    void DisableUIControls()
    {
        myControls.ui.Disable();
        myControls.ui.Pointer.Disable();
        myControls.gameplay.Look.Enable();
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


    public void PauseGame()
    {
        if (bIsGamePaused)
        {
            EnableUIControls();
            Time.timeScale = 0.0f;

        }
        else
        {
            DisableUIControls();
            Time.timeScale = 1.0f;
        }
    }

    public void ShowMenu(GameObject menuGO)
    {
        bIsGamePaused = !bIsGamePaused;
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
