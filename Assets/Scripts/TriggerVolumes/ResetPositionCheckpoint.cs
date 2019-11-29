using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionCheckpoint : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)    
    {
        if(other.gameObject)
        {
            if(other.gameObject.GetComponent<Player>())
            {
                SaveManager.LoadPlayerPosition();
            }
        }    
    }
}
