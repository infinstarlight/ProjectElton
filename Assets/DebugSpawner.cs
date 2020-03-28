using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpawner : MonoBehaviour
{

     public InputAction SpawnItemAction;
     public GameObject ItemToSpawn;

     void Awake()
     {
      SpawnItemAction.started += SpawnItem;
     }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    private void OnEnable() {
        SpawnItemAction.Enable();
    }

    private void OnDisable() {
        SpawnItemAction.Disable();
    }


    private void FixedUpdate() 
    {
        // if(Keyboard.current.a)
        // {
        //     Debug.Log("Test!");
        // }    
    }

    void SpawnItem(InputAction.CallbackContext context)
    {
        if(ItemToSpawn)
        {
            Instantiate(ItemToSpawn, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogError("No item is selected!");
        }
    }
}
