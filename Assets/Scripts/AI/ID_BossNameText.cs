using TMPro;
using UnityEngine;

public class ID_BossNameText : MonoBehaviour
{
    public TMP_Text nameText;
    public Material textMaterial;
    // Start is called before the first frame update
    void Start()
    {
        nameText = GetComponent<TMP_Text>();
        textMaterial = nameText.material;
        
    }

   
}
