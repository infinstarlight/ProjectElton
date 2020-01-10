using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class AragonTextScript : MonoBehaviour
{
    public TextMeshProUGUI TextMesh;

    private void Awake()
    {
        TextMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {

    }
}
