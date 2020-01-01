using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    public bool bShowFPS = false;
    float deltaTime = 0.0f;
    public bool bIsDebug = false;
    public bool bEnableFPSLimit = false;
    public int testFrameRate = 30;
    private ID_DebugCanvas debugCanvas;

    private GameObject graphyGO;
    // Start is called before the first frame update
    void Start()
    {
        debugCanvas = FindObjectOfType<ID_DebugCanvas>();
        //debugCanvasGO = debugCanvas.gameObject;
        if (Debug.isDebugBuild || Application.isEditor)
        {
            bIsDebug = true;
            if (bEnableFPSLimit)
            {
                Application.targetFrameRate = testFrameRate;
            }
            else
            {
#if UNITY_STANDALONE
                Application.targetFrameRate = 120;
#endif
#if UNITY_IOS || UNITY_ANDROID
                Application.targetFrameRate = 30;
#endif
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        // if (!debugCanvas)
        // {
        //     debugCanvas = FindObjectOfType<ID_DebugCanvas>();

        // }
        if (Keyboard.current.f3Key.wasPressedThisFrame)
        {
            bIsDebug = !bIsDebug;
        }
        if (Keyboard.current.f2Key.wasPressedThisFrame)
        {
            bShowFPS = !bShowFPS;
        }
        ToggleFPSLimit();
        if (bIsDebug)
        {
            if (Keyboard.current.downArrowKey.wasPressedThisFrame)
            {
                var StatGO = Resources.Load<GameObject>("Prefabs/Debug/StatsMonitor") as GameObject;

                Instantiate(StatGO);
                graphyGO = StatGO;
            }
            if (Keyboard.current.homeKey.wasPressedThisFrame)
            {
                bEnableFPSLimit = !bEnableFPSLimit;

            }
            if (bShowFPS)
            {
                if (graphyGO)
                {
                    graphyGO.SetActive(true);
                }
                // debugCanvasGO.SetActive(true);

            }
            else
            {
                //                debugCanvasGO.SetActive(false);
                if (graphyGO)
                {
                    graphyGO.SetActive(false);
                }

            }
        }
    }

    void ToggleFPSLimit()
    {
        //bTestFPSLimit = !bTestFPSLimit;
        if (bEnableFPSLimit)
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
