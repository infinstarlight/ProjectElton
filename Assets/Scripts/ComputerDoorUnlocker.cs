using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerDoorUnlocker : MonoBehaviour, IInteractable
{
    public LoadingDoorScript boundDoor;
  

    public void OnInteract()
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
