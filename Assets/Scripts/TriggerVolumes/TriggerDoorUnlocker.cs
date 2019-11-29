using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorUnlocker : MonoBehaviour
{
    public LoadingDoorScript boundDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   private void OnTriggerEnter(Collider other) 
   {
        if(other.gameObject)
        {
            if(other.gameObject.GetComponent<Player>())
            {
                if(boundDoor.bIsLocked)
                {
                    boundDoor.UnlockDoor();
                }
            }
        }    
   }
}
