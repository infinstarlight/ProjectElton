using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    public bool bShowFPS = false;
    float deltaTime = 0.0f;
    public bool bIsDebug = false;
    public bool bTestFPSLimit = false;
    public int testFrameRate = 30;
    private ID_DebugCanvas debugCanvas;
    private GameObject debugCanvasGO;
    // Start is called before the first frame update
    void Start()
    {
        if (Debug.isDebugBuild || Application.isEditor)
        {
            bIsDebug = true;
            Application.targetFrameRate = testFrameRate;
            debugCanvas = FindObjectOfType<ID_DebugCanvas>();
            debugCanvasGO = debugCanvas.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        if (bIsDebug)
        {
            if (Input.GetKeyDown(KeyCode.End))
            {
                var StatGO = Resources.Load<GameObject>("Prefabs/Debug/StatsMonitor") as GameObject;
                Instantiate(StatGO);
            }
            EnableFPSLimit();
        }
    }

    void EnableFPSLimit()
    {
        //bTestFPSLimit = !bTestFPSLimit;
        if (bTestFPSLimit)
        {
            Application.targetFrameRate = testFrameRate;
        }
        else
        {
            Application.targetFrameRate = -1;
        }

    }

    // void OnGUI()
    // {
    //     int w = Screen.width, h = Screen.height;

    //     GUIStyle style = new GUIStyle();

    //     Rect rect = new Rect(0, 0, w, h * 2 / 100);
    //     style.alignment = TextAnchor.LowerRight;
    //     style.fontSize = h * 2 / 100;
    //     style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
    //     float msec = deltaTime * 1000.0f;
    //     float fps = 1.0f / deltaTime;
    //     string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
    //     GUI.Label(rect, text, style);
    // }

}
