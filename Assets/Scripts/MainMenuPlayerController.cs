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

    void DisableControls()
    {

        Cursor.lockState = CursorLockMode.Locked;
        myControls.UI.Disable();
        myControls.UI.Point.Disable();
        myControls.UI.Navigate.Disable();
        myControls.UI.Submit.Disable();
        myControls.UI.Cancel.Disable();
        myControls.UI.Click.Disable();
        myControls.UI.RightClick.Disable();
        myControls.UI.MiddleClick.Disable();
        myControls.UI.ScrollWheel.Disable();
    }
}
