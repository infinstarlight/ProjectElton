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
        rbMovement = GetComponentInParent<InputSystem_RigidbodyCharacterMovement>();
        cameraLook = GetComponentInChildren<InputSystem_CameraLook>();
        combatController = GetComponent<InputSystem_PlayerCombatController>();
        if (myControls == null)
        {
            myControls = new GameInputControls();
        }

        myControls.gameplay.MoveRight.performed += rbMovement.OnMoveRight;
        myControls.gameplay.MoveUp.performed += rbMovement.OnMoveUp;
        myControls.gameplay.Sprint.performed += rbMovement.OnSprint;
        myControls.gameplay.Jump.performed += rbMovement.OnJump;
        myControls.gameplay.SpecialAbility.performed += rbMovement.OnSpecialAbility;
        myControls.gameplay.StyleSwitchUp.performed += combatController.StyleSwitcher;
        myControls.gameplay.SelectWeaponOne.performed += combatController.OnPrimaryWeaponSelect;
        myControls.gameplay.SelectWeaponTwo.performed += combatController.OnSecondWeaponSelect;
        myControls.gameplay.SelectWeaponOne.Enable();
        myControls.gameplay.SelectWeaponTwo.Enable();
        myControls.gameplay.SpecialAbility.Enable();
        myControls.gameplay.Sprint.Enable();
        myControls.gameplay.Jump.Enable();
        myControls.gameplay.MoveRight.Enable();
        myControls.gameplay.MoveUp.Enable();
        myControls.gameplay.StyleSwitchUp.Enable();
    }

    void OnDisable()
    {
        myControls.Disable();
        myControls.gameplay.SelectWeaponOne.Disable();
        myControls.gameplay.SelectWeaponTwo.Disable();
        myControls.gameplay.Sprint.Disable();
        myControls.gameplay.SpecialAbility.Disable();
        myControls.gameplay.Jump.Disable();
        myControls.gameplay.MoveRight.Disable();
        myControls.gameplay.MoveUp.Disable();
        myControls.gameplay.StyleSwitchUp.Disable();
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





}
