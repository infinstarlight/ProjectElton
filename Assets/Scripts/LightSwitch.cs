using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
    public Light myLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnInteract()
    {
        Debug.Log("Hello!");
        if(myLight.gameObject)
        {
            if(myLight.gameObject.activeSelf)
            {
                myLight.gameObject.SetActive(false);
            }
            else
            {
                myLight.gameObject.SetActive(true);
            }
        }
    }
}
