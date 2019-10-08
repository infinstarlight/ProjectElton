using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ID_EnemyLockOnImage : MonoBehaviour
{
    public Image targetImage;
    void Awake() 
    {
        targetImage = GetComponent<Image>();    
    }
    private void Start() 
    {
        //gameObject.SetActive(false);
    }
    

  
}
