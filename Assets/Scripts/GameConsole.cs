using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Popcron.Console;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine;

public class GameConsole : MonoBehaviour
{
    private bool bShouldOpenConsole = false;
    private GameObject consoleGO;
    private TMP_InputField consoleInputField;
    private EventSystem myEventSystem;

    

    private void Awake() 
    {
        consoleGO = GetComponentInChildren<Canvas>().gameObject;    
        consoleInputField = GetComponentInChildren<TMP_InputField>();
        consoleGO.SetActive(false);
        consoleInputField.DeactivateInputField();
        myEventSystem = EventSystem.current;
    }

    // Start is called before the first frame update
    void Start()
    {
        Console.Open = false;
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(Keyboard.current.backquoteKey.wasPressedThisFrame)
    //     {
    //         bShouldOpenConsole = !bShouldOpenConsole;
    //         if(bShouldOpenConsole)
    //         {
    //             consoleGO.SetActive(true);
    //             myEventSystem.SetSelectedGameObject(consoleInputField.gameObject);
    //             consoleInputField.ActivateInputField();
                
    //         }
    //         else
    //         {
    //             consoleGO.SetActive(false);
    //             consoleInputField.DeactivateInputField();
    //         }
            
    //     }
        
    // }

    public void ProcessInput()
    {

    }
}
