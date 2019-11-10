using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SaveGameButtonCheck : MonoBehaviour
{

    public Button GetButton;

    

    // Start is called before the first frame update
    void Start()
    {
         GetButton = GetComponent<Button>();

        if (System.IO.File.Exists(Application.persistentDataPath + "/player.sav"))
        {
            GetButton.interactable = true;
        }
        else
        {
            GetButton.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
