using UnityEngine;
using UnityEngine.InputSystem;

public class MyInputSystemController : MonoBehaviour
{

    public GameInputControls myControls;
    public float xAxis = 0.0f;
    public float yAxis = 0.0f;
    public InputSystem_CameraLook cameraLook;
 
    
    void OnEnable()
    {
        cameraLook = GetComponentInChildren<InputSystem_CameraLook>();
        if(myControls == null)
        {
            myControls = new GameInputControls();
        }
        myControls.gameplay.Look.performed += cameraLook.OnLook;
        myControls.gameplay.Fire.performed += OnAttack;
        // myControls.gameplay.MoveRight.performed += OnMoveRight;
        // myControls.gameplay.MoveUp.performed += OnMoveUp;
        myControls.gameplay.Fire.Enable();
        // myControls.gameplay.MoveRight.Enable();
        // myControls.gameplay.MoveUp.Enable();
        myControls.gameplay.Look.Enable();
    }

    void OnDisable()
    {
        myControls.Disable();
        myControls.gameplay.Fire.Disable();
        // myControls.gameplay.MoveRight.Disable();
        // myControls.gameplay.MoveUp.Disable();
        myControls.gameplay.Look.Disable();
    }

    void Fire()
    {
        Debug.Log("Fire!");
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Fire();
    }

    // public void OnMoveUp(InputAction.CallbackContext context)
    // {
    //     var yValue = context.ReadValue<float>();
    //     yAxis = yValue * 15 * Time.deltaTime;
    //     Debug.Log(yAxis);
    // }

    // public void OnMoveRight(InputAction.CallbackContext context)
    // {
    //     var xValue = context.ReadValue<float>();
    //     xAxis = xValue * 15 * Time.deltaTime;
    //     Debug.Log(xAxis);
    // }
}
