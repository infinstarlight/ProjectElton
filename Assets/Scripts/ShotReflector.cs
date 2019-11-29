using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotReflector : MonoBehaviour
{
    private GameObject hitObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  private void OnCollisionEnter(Collision other) 
  {
        if(other.gameObject)
        {
            hitObject = other.gameObject;
            if(hitObject.tag == "Projectile")
            {
                Instantiate(hitObject,transform.forward,transform.rotation);
            }
        }
  }
}
