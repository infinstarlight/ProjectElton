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

    // Update is called once per frame
    void Update()
    {

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
        myControls.ui.Pointer.Enable();
        myControls.ui.Submit.Enable();
        myControls.ui.Cancel.Enable();
        myControls.ui.Click.Enable();
    }
}
