using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine;

public class InputSystemPlayerInput : MonoBehaviour
{
    Vector2 moveVector = new Vector2();
    GameInputControls myControls;

    bool bWantsToRun = false;
    bool bWantsToCrouch = false;
    public void OnMoveUpdate(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();

    }
    public Vector2 input
    {
        get
        {
            Vector2 i = Vector2.zero;
            i.x = moveVector.x;
            i.y = moveVector.y;
            i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;
            //Debug.Log(i);
            return i;
        }
    }

    public Vector2 down
    {
        get { return _down; }
    }

    public Vector2 raw
    {
        get
        {
            Vector2 i = Vector2.zero;
            i.x = Mouse.current.position.x.ReadUnprocessedValue();
            i.y = Mouse.current.position.y.ReadUnprocessedValue();
            i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;
            return i;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                {
                    bWantsToRun = true;
                }
                break;
            case InputActionPhase.Canceled:
                {
                    bWantsToRun = false;
                }
                break;
        }

    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        bWantsToCrouch = !bWantsToCrouch;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //bWantsToJump = !bWantsToJump;
    }

    public bool run
    {
        get { return Keyboard.current.leftShiftKey.isPressed; }
    }

    public bool crouch
    {
        get { return Keyboard.current.cKey.wasPressedThisFrame; }
    }

    public bool crouching
    {
        get { return Keyboard.current.cKey.isPressed; }
    }

    private Vector2 previous;
    private Vector2 _down;

    private int jumpTimer;
    private bool bWantsToJump = false;
    //private bool bCanJump = false;
    private Keyboard currentKeyboard;
    private InputSystemPlayerMovement playerMovement;

    private void Awake()
    {
        if (myControls == null)
        {
            myControls = new GameInputControls();
        }
        myControls.Gameplay.Move.performed += OnMoveUpdate;
        myControls.Gameplay.Sprint.performed += OnRun;
        myControls.Gameplay.Sprint.canceled += OnRun;
        myControls.Gameplay.Jump.performed += OnJump;
        myControls.Gameplay.Jump.canceled += OnJump;
        myControls.Gameplay.Crouch.performed += OnCrouch;
        myControls.Gameplay.Crouch.canceled += OnCrouch;
        currentKeyboard = Keyboard.current;
        InputSystem.pollingFrequency = 120;
        playerMovement = GetComponentInParent<InputSystemPlayerMovement>();
    }

    void Start()
    {
        jumpTimer = -1;
    }

    void Update()
    {
        _down = Vector2.zero;
        if (raw.x != previous.x)
        {
            previous.x = raw.x;
            if (previous.x != 0)
                _down.x = previous.x;
        }
        if (raw.y != previous.y)
        {
            previous.y = raw.y;
            if (previous.y != 0)
                _down.y = previous.y;
        }


    }

    public void FixedUpdate()
    {
        // myControls.Gameplay.Jump.started += ctx =>
        // {
        //     var control = ctx.control; // Grab control.
        //                                // Can do control-specific checks.
        //     var button = control as ButtonControl;

        //     if (!button.isPressed)
        //     {
        //         bWantsToJump = false;
        //         jumpTimer++;
        //     }
        //     else if (jumpTimer > 0)
        //     {
        //         bWantsToJump = true;
        //     }
        // };
        //|| Gamepad.current.buttonSouth.isPressed
        if (!Keyboard.current.spaceKey.isPressed)
        {
            bWantsToJump = false;
            jumpTimer++;
        }
        else if (jumpTimer > 0)
        {
            bWantsToJump = true;
        }


    }


    public bool Jump()
    {
        return bWantsToJump;
    }

    public void ResetJump()
    {
        jumpTimer = -1;
    }
}
