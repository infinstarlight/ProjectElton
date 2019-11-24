using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputSystem_TouchJoystick : MonoBehaviour
{
    //public InputAction moveAction;
    private InputSystem_RigidbodyCharacterMovement GetCharacterMovement;
    private void Awake() 
    {
        GetCharacterMovement = FindObjectOfType<InputSystem_RigidbodyCharacterMovement>();    

        var moveUpAction = new InputAction("MoveUp");
        //moveUpAction.AddBinding("Axis",)
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
