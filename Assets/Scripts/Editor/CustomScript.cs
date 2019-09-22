using UnityEditor;
using UnityEngine;

public class CustomScript : MonoBehaviour
{
    // Add a menu item named "Do Something" to MyMenu in the menu bar.
    [MenuItem("MyMenu/Do Something")]
    static void DoSomething()
    {
        Debug.Log("Doing Something...");
    }

    [MenuItem("MyMenu/Spawn Graphy")]
    static void SpawnGraphy()
    {
        var StatGO = Resources.Load<GameObject>("Prefabs/Debug/StatsMonitor") as GameObject;
        Instantiate(StatGO);
    }
}
