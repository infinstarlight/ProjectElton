using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTextScript : MonoBehaviour
{
    public TextMeshProUGUI TextMesh;

    private void Awake()
    {
        TextMesh = GetComponent<TextMeshProUGUI>();
    }
}
