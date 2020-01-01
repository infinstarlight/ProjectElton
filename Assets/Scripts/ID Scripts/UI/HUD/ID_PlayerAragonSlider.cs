using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ID_PlayerAragonSlider : MonoBehaviour
{
    public Slider aragonSlider;
    
    // Start is called before the first frame update
    private void Start()
    {
         aragonSlider = GetComponent<Slider>();
    }   
}
