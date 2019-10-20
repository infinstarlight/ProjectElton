using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ID_PlayerHealthSlider : MonoBehaviour
{
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GetComponent<Slider>();
    }

   
}
