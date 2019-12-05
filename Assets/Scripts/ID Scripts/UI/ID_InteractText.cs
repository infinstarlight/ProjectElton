using TMPro;
using UnityEngine;

public class ID_InteractText : MonoBehaviour
{
    public TMP_Text textObject;
    public Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        textObject = GetComponent<TMP_Text>();
        myAnimator = GetComponent<Animator>();
    }

   
}
