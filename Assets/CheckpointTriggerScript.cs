using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTriggerScript : MonoBehaviour
{
    private SaveManager GetSaveManager;
    // Start is called before the first frame update
    void Start()
    {
        GetSaveManager = FindObjectOfType<SaveManager>();
    }

   private void OnTriggerEnter(Collider other) 
   {
        if(other.gameObject)
        {
            if(other.gameObject.GetComponent<Player>())
            {
                GetSaveManager.SavePlayerData();
            }
        }    
   }
}
