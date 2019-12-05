using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemPreferences : MonoBehaviour
{

    public string GraphicsPresetName = "";


    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }


}
