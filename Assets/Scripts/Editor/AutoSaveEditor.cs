﻿#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class AutoSaveEditor : MonoBehaviour
{
    private static DateTime nextSaveTime;

    // Static constructor that gets called when unity fires up.
    static AutoSaveEditor()
    {
        // EditorApplication.playModeStateChanged += (PlayModeStateChange state) =>
        // {
        //     // If we're about to run the scene...
        //     if (!EditorApplication.isPlayingOrWillChangePlaymode || EditorApplication.isPlaying) return;

        //     // Save the scene and the assets.
        //     Debug.Log("Auto-saving all open scenes... " + state);
        //     EditorSceneManager.SaveOpenScenes();
        //     AssetDatabase.SaveAssets();
        // };

        // Also, every five minutes.
        nextSaveTime = DateTime.Now.AddMinutes(5);
        EditorApplication.update += Update;
        Debug.Log("Added callback.");
    }

    private static void Update()
    {
        if (nextSaveTime > DateTime.Now) return;

        nextSaveTime = nextSaveTime.AddMinutes(5);

        Debug.Log("AutoSave Scenes: " + DateTime.Now.ToShortTimeString());
        if (!EditorApplication.isPlaying)
        {
            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
        }
        else
        {
            Debug.LogWarning("We cannot save while Play Mode is Active!");
        }

    }
}
#endif
