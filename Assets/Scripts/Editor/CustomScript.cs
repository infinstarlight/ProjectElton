using UnityEditor;
using UnityEngine;

public class CustomScript : MonoBehaviour
{
    

    [MenuItem("System/Spawn Graphy")]
    static void SpawnGraphy()
    {
        var StatGO = Resources.Load<GameObject>("Prefabs/Debug/StatsMonitor") as GameObject;
        Instantiate(StatGO);
        
    }
}
