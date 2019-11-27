using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerDoorUnlocker : MonoBehaviour, IInteractable
{
    public LoadingDoorScript boundDoor;
    public bool bIsUnlockingDoor = false;
    public bool bIsDisablingObject = false;
    public GameObject boundObject;
  

    public void OnInteract()
    {
        if(bIsDisablingObject)
        {
            if(boundObject)
            {
                boundObject.SetActive(false);
            }
        }
        if(bIsUnlockingDoor)
        {
            if(boundDoor)
        {
            if(boundDoor.bIsLocked)
            {
                boundDoor.bIsLocked = false;
            }
        }
        }   
        
    }
}
