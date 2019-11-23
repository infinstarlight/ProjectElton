using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource), typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{

    private Rigidbody rb;

    public float hitForce = 0.0f;
    public float PushbackForce = 50.0f; 
    public Vector3 oldVelocity;

    public float DamageAmount = 0.0f;
    public GameObject explosionGO;
    private AudioSource source;
    private GameObject hitObject;
    public Vector3 PushbackVector = new Vector3(0,1,0);

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * hitForce;
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject, 5f);
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * hitForce);
        oldVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            hitObject = other.gameObject;
            // rb.isKinematic = true;
            // rb.Sleep();
            if (hitObject.GetComponent<Enemy>())
            {
                Explode();
                hitObject.SendMessage("OnEnemyDamageApplied", DamageAmount);
                hitObject.GetComponent<Rigidbody>().AddForce(PushbackVector * PushbackForce,ForceMode.Acceleration);
            }

        }
    }

    void Explode()
    {
        Instantiate(explosionGO, transform.position, transform.rotation);
        source.PlayOneShot(source.clip);
        Destroy(gameObject, 1f);
    }


}
