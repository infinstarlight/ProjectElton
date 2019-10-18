using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputSystem_PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    private RigidbodyCharacterMovement rbMovement;
    private float MoveX;
    private float MoveY;
    private float LookX;
    private float LookY;
    GameInputControls myControls;

    void Awake()
    {
        myControls = new GameInputControls();
        
        rbMovement = GetComponentInParent<RigidbodyCharacterMovement>();
        
        moveAction.AddCompositeBinding("Axis").With("Positive","<Keyboard>/w").With("Negative","<Keyboard>/s");
        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

     public void OnMove(InputAction.CallbackContext context)
    {
        MoveX = context.ReadValue<float>();
        MoveY = context.ReadValue<float>();
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
