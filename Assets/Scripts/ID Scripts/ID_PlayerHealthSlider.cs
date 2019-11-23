using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ID_PlayerHealthSlider : MonoBehaviour
{
    public Slider healthSlider;
    private void Awake() 
    {
        healthSlider = GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
}
