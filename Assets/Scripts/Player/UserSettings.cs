using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserSettings 
{

    public float savedMouseSensitivity;
    public Resolution currentResolution;

    public UserSettings(PlayerConfig config)
    {
        savedMouseSensitivity = config.currentMouseSensitivity;
    }

    
}
