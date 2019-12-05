using UnityEngine.InputSystem;
using UnityEngine;

public class MainMenuPlayerController : MonoBehaviour
{
    private GameInputControls myControls;
    private Keyboard currentKeyboard;
    private Gamepad currentGamepad;
    private Touchscreen currentTouchscreen;

    private void Awake()
    {
        EnableControls();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentKeyboard = Keyboard.current;
        currentGamepad = Gamepad.current;
        currentTouchscreen = Touchscreen.current;
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        DisableControls();
    }


    void EnableControls()
    {
        if (myControls == null)
        {
            myControls = new GameInputControls();
        }
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }
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

    void DisableControls()
    {

        Cursor.lockState = CursorLockMode.Locked;
        myControls.ui.Disable();
        myControls.ui.Point.Disable();
        myControls.ui.Navigate.Disable();
        myControls.ui.Submit.Disable();
        myControls.ui.Cancel.Disable();
        myControls.ui.Click.Disable();
        myControls.ui.RightClick.Disable();
        myControls.ui.MiddleClick.Disable();
        myControls.ui.ScrollWheel.Disable();
    }
}
