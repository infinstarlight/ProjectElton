using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlockScript : MonoBehaviour
{
    public bool bToggleLockStatus = false;
    public GameObject boundDoorGO;
    private LoadingDoorScript GetDoorScript;
    private void Awake() 
    {
        if(boundDoorGO)
        {
            GetDoorScript = boundDoorGO.GetComponent<LoadingDoorScript>();
        }    
        else
        {
            Debug.LogError("There is no door associated with this trigger!");
        }
    }
   
   private void OnTriggerExit(Collider other) 
   {
        GameObject hitObject = null;
        if(other.gameObject)
        {
            hitObject = other.gameObject;
            if(hitObject.GetComponent<Player>())
            {
                ToggleDoorLock();
            }
        }    
   }


    void ToggleDoorLock()
    {
        if(boundDoorGO)
        {
            if(bToggleLockStatus)
            {
                GetDoorScript.bIsLocked = bToggleLockStatus;
                GetDoorScript.doorCloseEvent.Invoke();
            }
            else
            {
                GetDoorScript.doorUnlockEvent.Invoke();
            }
        }
    }
}
