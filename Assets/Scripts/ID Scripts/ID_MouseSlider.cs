using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ID_MouseSlider : MonoBehaviour
{
    public Slider mySlider;

    void Awake()
    {
        mySlider = GetComponent<Slider>();
        mySlider.value = 5.0f;
    }
}
