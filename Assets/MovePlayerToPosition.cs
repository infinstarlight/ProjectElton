using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToPosition : MonoBehaviour
{
    private GameObject PlayerGO;

    public GameObject InstPlayerGO;
    public GameObject PlayerUIGO;
    
    // Start is called before the first frame update
    void Start()
    {
//        PlayerGO = FindObjectOfType<Player>().gameObject;
        if(PlayerGO)
        {
            PlayerGO.transform.position = transform.position;
        }
        else
        {
            Instantiate(PlayerUIGO);
            Instantiate(InstPlayerGO,transform.position,transform.rotation);
            
        }
        
    }

  
}
