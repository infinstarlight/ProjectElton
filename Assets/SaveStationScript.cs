using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStationScript : MonoBehaviour
{
    private Player GetPlayer;
    private GameObject saveScreenGO;
    // Start is called before the first frame update
    void Start()
    {
        var screenGO = Resources.Load<GameObject>("UI/SaveStationScreen") as GameObject;
        saveScreenGO = screenGO;
    }

  private void OnTriggerEnter(Collider other) 
  {
        if(other.gameObject)
        {
            if(other.gameObject.GetComponent<Player>())
            {
                GetPlayer = other.gameObject.GetComponent<Player>();
                if(saveScreenGO)
                {
                    Instantiate(saveScreenGO,transform);
                    GetPlayer.pCon.EnableUIInputEvent.Invoke();
                }
            }
        }
  }
}
