using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScreenUIController : MonoBehaviour
{
    private Player GetPlayer;
    private GameObject myObject;
    // Start is called before the first frame update
    void Start()
    {
        GetPlayer = FindObjectOfType<Player>();
        
    }

    public void AcceptSave()
    {
        SaveManager.SavePlayerData();
        GetPlayer.pCon.DisableUIInputEvent.Invoke();
        Destroy(gameObject);
    }

    public void RejectSave()
    {
        
        GetPlayer.pCon.DisableUIInputEvent.Invoke();
        Destroy(gameObject);
    }
}
