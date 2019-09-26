using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ID_StyleImage : MonoBehaviour
{
   public Image styleImage;

   void Awake()
   {
       styleImage = GetComponent<Image>();
   }
}
