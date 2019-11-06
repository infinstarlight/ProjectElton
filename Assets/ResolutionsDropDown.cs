using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ResolutionsDropDown : MonoBehaviour
{
    private Dropdown resDropDown;
    public List<Resolution> resolutionsList = new List<Resolution>();
    public List<string> resString = new List<string>();
    private int DisplayRefreshRate;
    private FullScreenMode fullScreen;

    void Awake()
    {
        resDropDown = GetComponent<Dropdown>();
        resDropDown.ClearOptions();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        Resolution[] resolutions = Screen.resolutions; //all resolution
        foreach (Resolution res in resolutions)
        {
            //
            resolutionsList.Add(res); //add resolution in list
            resString.Add(res.width.ToString() + "x" + res.height.ToString()); //string format every resolution
        }
        resDropDown.AddOptions(resString);


    }

    public void UpdateResolution(int Selection)
    {
        //int newRes = resolutionsList.FindIndex(x => x.Equals(Selection));
        Screen.SetResolution(resolutionsList[Selection].width,resolutionsList[Selection].height,fullScreen,resolutionsList[Selection].refreshRate);
        Debug.Log(Screen.currentResolution);
    }
}
