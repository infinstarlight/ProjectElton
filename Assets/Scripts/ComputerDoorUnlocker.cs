using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerDoorUnlocker : MonoBehaviour, IInteractable
{
    public LoadingDoorScript boundDoor;
    // Start is called before the first frame update
    void Start()
    {

    }

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
