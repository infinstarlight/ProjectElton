using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysReflectTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   private void OnTriggerEnter(Collider other) 
   {
        if(other.gameObject)
        {
            if(other.gameObject.GetComponent<Rigidbody>())
            {
                PhysicsReflector.OnReflectEvent.Invoke(other.gameObject.GetComponent<Rigidbody>());
            }
        }    
   }
}
