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
        
        if (PlayerGO)
        {
            PlayerGO.transform.position = transform.position;
        }
        if (!PlayerGO)
        {
            PlayerGO = FindObjectOfType<Player>().gameObject;
            PlayerGO.transform.position = transform.position;
           
            
        }

    }

    void Update()
    {
        if (!PlayerGO)
        {
            PlayerGO = FindObjectOfType<Player>().gameObject;
        }
    }


}
