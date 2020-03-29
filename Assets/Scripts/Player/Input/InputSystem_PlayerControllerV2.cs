﻿using UnityEngine.Events;
using UnityEngine.InputSystem;
using Lowscope.Saving;
using Popcron.Console;
using DG.Tweening;
using UnityEngine;


public class InputSystem_PlayerControllerV2 : MonoBehaviour
{

  
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
    [SerializeField]
    private bool bActivateSpecial = false;
    public InputAction ToggleMouseStateAction;
    private bool bEnable;
    public Player GetPlayer;
    private Sequence satSequence;
    public InputSystemPlayerInput GetPlayerInput;
    private InputSystemPlayerMovement GetMovement;
    private InputSystemCameraMovement GetCameraMovement;
    Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
    GameObject currentEnemy = null;
    RaycastHit LockOnHit;
    private Ray lockOnRay;
    [SerializeField]
    private float lockOnRadius = 100f;
    [SerializeField]
    private float lockOnRange = 200f;
    [SerializeField]
    private bool bStartLockOn = false;


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
        GetPlayer = GetComponentInParent<Player>();

        HUDGO = FindObjectOfType<ID_PlayerHUD>().gameObject;
        CharMenuGO = FindObjectOfType<ID_CharMenu>().gameObject;
        PauseMenuGO = FindObjectOfType<ID_PauseMenu>().gameObject;
        EnableGameControls();
        bEnableGameInput = true;
        bShowPauseMenu = false;


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
        GetCameraMovement = playerCamera.GetComponent<InputSystemCameraMovement>();
        //EnhancedTouchSupport.Enable();
        lockOnRay = playerCamera.ViewportPointToRay(rayOrigin);

    }


    private void OnEnable()
    {
        Parser.Register(this, "player");
        //EnableUIControls();
        ToggleMouseStateAction.Enable();
    }

    void OnDisable()
    {
        DisableGameControls();
        EnableGameInputEvent.RemoveAllListeners();
        DisableGameInputEvent.RemoveAllListeners();
        EnableUIInputEvent.RemoveAllListeners();
        DisableUIInputEvent.RemoveAllListeners();
        //  PauseGameEvent.RemoveAllListeners();
        ToggleMouseStateAction.Disable();
        Parser.Unregister(this);
    }



    void Start()
    {
        EnableGameInputEvent.AddListener(EnableGameControls);
        DisableGameInputEvent.AddListener(DisableGameControls);
        EnableUIInputEvent.AddListener(EnableUIControls);
        DisableUIInputEvent.AddListener(DisableUIControls);
        //PauseGameEvent.AddListener(PauseGame);

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
        //CheckForNewDevice();
        if (Keyboard.current.numpad0Key.wasPressedThisFrame)
        {
            SaveMaster.SyncLoad();
        }
        if (bStartLockOn)
        {
            CheckForLockOn();
            // LockOn();
        }

    }
    private void FixedUpdate()
    {
        CheckForInteractionPoint();
    }

    void CheckForInteractionPoint()
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

    void CheckForLockOn()
    {
        // Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
        GameObject hitObject = null;
        // Vector3 playerPostion = transform.position + playerCamera.transform.forward;
        // RaycastHit LockOnHit;
        // actual Ray
        Ray ray = playerCamera.ViewportPointToRay(rayOrigin);

        if (Physics.SphereCast(ray.origin, lockOnRadius, ray.direction, out LockOnHit, lockOnRange))
        {
            if (LockOnHit.collider)
            {
                hitObject = LockOnHit.collider.gameObject;
                {

                    if (hitObject.GetComponent<Character>() != null || hitObject.GetComponent<IDamageable<float>>() != null)
                    {
                        playerCamera.transform.LookAt(hitObject.transform);
                        GetCameraMovement.ModifyCameraClamp(new Vector2(30, 90));
                        Debug.Log("Locking on to target!");
                    }
                    else
                    {
                        GetCameraMovement.ResetCameraClamp();
                        Debug.Log("Lock on target not valid!");
                    }
                }
            }
        }
        // if (Physics.Raycast(ray, out hit, InteractRange))
        // {
        //     if (hit.collider)
        //     {
        //         hitObject = hit.collider.gameObject;
        //         if (hitObject.GetComponent<Character>() != null || hitObject.GetComponent<IDamageable<float>>() != null)
        //         {
        //             playerCamera.transform.LookAt(hitObject.transform);
        //             GetCameraMovement.ModifyCameraClamp(new Vector2(30, 90));
        //         }
        //         else
        //         {
        //             // uiController.bShowInteractText = false;
        //             // uiController.showInteractEvent.Invoke();
        //             GetCameraMovement.ResetCameraClamp();
        //         }
        //     }

        // }
    }

    void LockOn()
    {

        if (bStartLockOn)
        {
            Debug.DrawRay(lockOnRay.origin, lockOnRay.direction * 5000.0f, Color.blue);


            // actual Ray

            // if (Physics.Raycast(lockOnRay, out LockOnHit, lockOnRange))
            // {
            //     if (LockOnHit.collider)
            //     {
            //         currentEnemy = LockOnHit.collider.gameObject.GetComponent<Enemy>();
            //         if (currentEnemy)
            //         {
            //             transform.LookAt(currentEnemy.gameObject.transform);
            //             currentEnemy.enemyUIController.bIsTargeted = true;
            //             Debug.Log("Hit: " + currentEnemy.name);
            //         }
            //     }
            // }
            if (Physics.SphereCast(lockOnRay.origin, 5000.0f, lockOnRay.direction, out LockOnHit, 5000.0f))
            {
                if (LockOnHit.collider)
                {

                    if (currentEnemy.GetComponent<Character>() != null || currentEnemy.GetComponent<IDamageable<float>>() != null)
                    {
                        transform.LookAt(currentEnemy.gameObject.transform);
                        //currentEnemy.enemyUIController.bIsTargeted = true;
                        Debug.Log("Hit: " + currentEnemy.name);
                    }
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
        if (!GetGameInstance)
        {
            GetGameInstance = FindObjectOfType<GameInstance>();
        }
        if (!GetPlayerInput)
        {
            GetPlayerInput = GetComponent<InputSystemPlayerInput>();
        }
        if (!GetMovement)
        {
            GetMovement = GetComponentInParent<InputSystemPlayerMovement>();
        }


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
        if (!combatController)
        {
            combatController = GetComponent<InputSystem_PlayerCombatController>();
        }

        if (myControls == null)
        {
            myControls = new GameInputControls();
        }
        bEnableGameInput = true;
        GetMovement.bPlayerControl = bEnableGameInput;


        myControls.Gameplay.Pause.performed += OnGamePause;
        myControls.Gameplay.Interact.performed += OnInteractEvent;
        myControls.Gameplay.CharacterMenu.performed += OnCharMenu;
        myControls.Gameplay.Move.performed += GetPlayerInput.OnMoveUpdate;
        myControls.Gameplay.Fire.performed += combatController.OnFire;
        myControls.Gameplay.Aim.performed += OnAimEvent;
        myControls.Gameplay.Aim.canceled += OnAimEvent;
        //  myControls.Gameplay.Dash.performed += rbMovement.OnSpecialAbility;
        myControls.Gameplay.SelectWeaponOne.performed += combatController.OnPrimaryWeaponSelect;
        myControls.Gameplay.SelectWeaponTwo.performed += combatController.OnSecondWeaponSelect;
        myControls.Gameplay.SelectWeaponThree.performed += combatController.OnThirdWeaponSelect;
        // myControls.Gameplay.Zoom.performed += cameraLook.OnZoom;
        // myControls.Gameplay.Look.performed += cameraLook.OnLook;
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
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }
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
        myControls.Gameplay.Disable();
    }

    void DisableUIControls()
    {
        myControls.UI.Disable();
        myControls.UI.Point.Disable();
        EnableGameControls();
    }

    public void OnAimEvent(InputAction.CallbackContext context)
    {

        bStartLockOn = !bStartLockOn;


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
                    //cameraLook.OnScanActivate();
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

    void TogglePause()
    {
        bIsGamePaused = !bIsGamePaused;
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


    public void PauseGame(bool bPauseState)
    {
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        bIsGamePaused = bPauseState;
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

    void CheckMenuStatus()
    {
        if (PauseMenuGO.activeSelf)
        {
            CharMenuGO.SetActive(false);
        }
        if (CharMenuGO.activeSelf)
        {
            PauseMenuGO.SetActive(false);
        }
    }

    public void ShowMenu(GameObject menuGO)
    {
        TogglePause();
        CheckMenuStatus();
        if (!bIsGamePaused)
        {
            if (!menuGO.activeSelf)
            {
                HUDGO.SetActive(false);
                menuGO.SetActive(true);
            }

        }
        if (bIsGamePaused)
        {
            if (!HUDGO.activeSelf)
            {
                HUDGO.SetActive(true);
                menuGO.SetActive(false);
            }

        }
    }

    public void HideMenu(GameObject menuGO)
    {
        if (menuGO)
        {
            PauseGame(false);
            HUDGO.SetActive(true);
            menuGO.SetActive(false);
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
                    //source.PlayOneShot(interactSounds[0]);
                }
            }

        }
    }

    void OnDrawGizmos()
    {
        if (bStartLockOn)
        {
            if (LockOnHit.collider)
            {
                //Draw a Ray forward from GameObject toward the hit
                Gizmos.DrawRay(transform.position, transform.forward * LockOnHit.distance);
                //Draw a cube that extends to where the hit exists
                Gizmos.DrawWireSphere(transform.position + transform.forward * LockOnHit.distance, lockOnRadius);
            }
            //If there hasn't been a hit yet, draw the ray at the maximum distance
            else
            {
                //Draw a Ray forward from GameObject toward the maximum distance
                Gizmos.DrawRay(transform.position, transform.forward * lockOnRange);
                //Draw a cube at the maximum distance
                Gizmos.DrawWireSphere(transform.position + transform.forward * lockOnRange, lockOnRadius);
            }
        }

    }



}