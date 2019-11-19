using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoxTriggerScript : MonoBehaviour
{
    public GameObject ObjectToModify;
    public bool bShouldEnable = false;

    void Awake()
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject)
        {
            if(other.gameObject.GetComponent<Player>())
            {
                if(bShouldEnable)
                {
                    ObjectToModify.SetActive(true);
                }
            }
        }    
    }

}
