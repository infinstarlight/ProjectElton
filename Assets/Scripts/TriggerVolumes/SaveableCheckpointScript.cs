using Lowscope.Saving;
using System;
using UnityEngine;

public class SaveableCheckpointScript : MonoBehaviour
{
    // private SaveManager GetSaveManager;
    // Start is called before the first frame update
    void Start()
    {
        //GetSaveManager = FindObjectOfType<SaveManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                SaveMaster.SyncSave();
            }
        }
    }
}
