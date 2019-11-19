using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource), typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{

    private Rigidbody rb;

    public float hitForce;
    public Vector3 oldVelocity;

    public float DamageAmount = 0.0f;
    public GameObject explosionGO;
    private AudioSource source;

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
        Destroy(gameObject, 5f);
    }

    void FixedUpdate()
    {
        oldVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            Explode();
            if (other.gameObject.GetComponent<Enemy>())
            {
                other.gameObject.SendMessage("OnEnemyDamageApplied", DamageAmount);
            }

        }
    }

    void Explode()
    {
        Instantiate(explosionGO, transform.position, transform.rotation);
        source.PlayOneShot(source.clip);
        Destroy(gameObject, 1.5f);
    }


}
