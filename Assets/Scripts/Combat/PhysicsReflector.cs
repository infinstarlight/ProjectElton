using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PhysicsReflector : MonoBehaviour
{
    public static UnityRigidbodyEvent OnReflectEvent = new UnityRigidbodyEvent();
    // Start is called before the first frame update
    void Start()
    {
        OnReflectEvent.AddListener(ReflectPhysicsObject);
    }

    

    void ReflectPhysicsObject(Rigidbody hitObjectRB)
    {
        if (hitObjectRB)
        {
            hitObjectRB.AddForce(Vector3.back * 50, ForceMode.Impulse);
        }
    }
}
