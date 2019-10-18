using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class HealthTextScript : MonoBehaviour
{
    public TextMeshProUGUI TextMesh;

    private void Awake()
    {
        TextMesh = GetComponent<TextMeshProUGUI>();
    }
}
