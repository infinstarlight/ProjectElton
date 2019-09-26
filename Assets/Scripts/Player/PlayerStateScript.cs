using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateScript : MonoBehaviour
{
    public float CurrentStyleAmount;
    public float StyleModAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModStyle(float ModAmount)
    {
        StyleModAmount = ModAmount;
        CurrentStyleAmount += StyleModAmount;
    }
}
