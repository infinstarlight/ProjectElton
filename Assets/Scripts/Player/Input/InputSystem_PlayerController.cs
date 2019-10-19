using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputSystem_PlayerController : MonoBehaviour
{


    private InputSystem_RigidbodyCharacterMovement rbMovement;
    private InputSystem_CameraLook cameraLook;
    private InputSystem_PlayerCombatController combatController;
    private GameInputControls myControls;
    public PlayerStateScript playerState;
    public bool bIsGamePaused = false;
    public bool bEnableInput = true;
    public GameObject PauseMenuGO;
    void OnEnable()
    {
        EnableGameControls();
    }

    void OnDisable()
    {
        DisableGameControls();
    }

    void Awake()
    {
        playerState = GetComponentInChildren<PlayerStateScript>();
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        PauseMenuGO = FindObjectOfType<ID_PauseMenu>().gameObject;

    }
    // Update is called once per frame
    void Update()
    {
        if (PauseMenuGO == null)
        {
            PauseMenuGO = FindObjectOfType<ID_PauseMenu>().gameObject;
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
                    break;
                case InputDeviceChange.Disconnected:
                    // Device got unplugged
                    break;
                case InputDeviceChange.Reconnected:
                    // Plugged back in
                    break;
                case InputDeviceChange.Removed:
                    // Remove from Input System entirely; by default, devices stay in the system once discovered
                    break;
                default:
                    // See InputDeviceChange reference for other event types.
                    break;
            }
        };
    }

    void EnableGameControls()
    {
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

        myControls.gameplay.Pause.performed += OnGamePause;
        myControls.gameplay.MoveRight.performed += rbMovement.OnMoveRight;
        myControls.gameplay.MoveUp.performed += rbMovement.OnMoveUp;
        myControls.gameplay.Sprint.performed += rbMovement.OnSprint;
        myControls.gameplay.Jump.performed += rbMovement.OnJump;
        myControls.gameplay.AltFire.performed += cameraLook.OnLockOn;
        myControls.gameplay.AltFire.canceled += cameraLook.OnLockOnStop;
        myControls.gameplay.SpecialAbility.performed += rbMovement.OnSpecialAbility;
        myControls.gameplay.StyleSwitchUp.performed += combatController.OnStyleSwitchUp;
        myControls.gameplay.StyleSwitchDown.performed += combatController.OnStyleSwitchDown;
        myControls.gameplay.SelectWeaponOne.performed += combatController.OnPrimaryWeaponSelect;
        myControls.gameplay.SelectWeaponTwo.performed += combatController.OnSecondWeaponSelect;
        myControls.gameplay.Zoom.performed += cameraLook.OnZoom;
        myControls.gameplay.Pause.Enable();
        myControls.gameplay.AltFire.Enable();
        myControls.gameplay.SelectWeaponOne.Enable();
        myControls.gameplay.SelectWeaponTwo.Enable();
        myControls.gameplay.SpecialAbility.Enable();
        myControls.gameplay.Sprint.Enable();
        myControls.gameplay.Jump.Enable();
        myControls.gameplay.MoveRight.Enable();
        myControls.gameplay.MoveUp.Enable();
        myControls.gameplay.StyleSwitchUp.Enable();
        myControls.gameplay.StyleSwitchDown.Enable();
    }

    void DisableGameControls()
    {
        myControls.Disable();
        myControls.gameplay.SelectWeaponOne.Disable();
        myControls.gameplay.AltFire.Disable();
        myControls.gameplay.SelectWeaponTwo.Disable();
        myControls.gameplay.Sprint.Disable();
        myControls.gameplay.SpecialAbility.Disable();
        myControls.gameplay.Jump.Disable();
        myControls.gameplay.MoveRight.Disable();
        myControls.gameplay.MoveUp.Disable();
        myControls.gameplay.StyleSwitchUp.Disable();
        myControls.gameplay.StyleSwitchDown.Disable();
    }

    void EnableUIControls()
    {
        myControls.gameplay.Disable();
        
        myControls.ui.Enable();
    }

    void DisableUIControls()
    {
        myControls.ui.Disable();
        myControls.gameplay.Enable();
    }

    public void OnGamePause(InputAction.CallbackContext context)
    {
        PauseGame();
    }


    public void PauseGame()
    {
        bIsGamePaused = !bIsGamePaused;
        if (bIsGamePaused)
        {
            EnableUIControls();
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0.0f;
            bEnableInput = false;
            if (PauseMenuGO)
            {
                if (!PauseMenuGO.activeSelf)
                {
                    PauseMenuGO.SetActive(true);
                }
            }
        }
        else
        {
            DisableUIControls();
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1.0f;
            bEnableInput = true;
            if (PauseMenuGO)
            {
                if (PauseMenuGO.activeSelf)
                {
                    PauseMenuGO.SetActive(false);
                }
            }
        }

    }


}
