using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Rigidbody rb;
    
    public float hitForce;
      public Vector3 oldVelocity;

     private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * hitForce;
    }

    // Update is called once per frame
    void Update()
    {
          Destroy(gameObject, 5f);
    }

    void FixedUpdate()
    {
   oldVelocity = rb.velocity;
    }
}
