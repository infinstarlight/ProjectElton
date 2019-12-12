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
    public Vector3 PushbackVector = new Vector3(0, 1, 0);
    private ParticleSystem explosionPS;
    public bool bIsPlayerProjectile = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        explosionPS = explosionGO.GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * hitForce;
        //explosionPS.loop = false;
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
            Explode();
            if (bIsPlayerProjectile)
            {
                if (hitObject.GetComponent<Enemy>())
                {

                    hitObject.SendMessage("OnEnemyDamageApplied", DamageAmount);
                    hitObject.GetComponent<Rigidbody>().AddForce(PushbackVector * PushbackForce, ForceMode.Acceleration);
                }
            }
            else
            {
                if (hitObject.GetComponent<Player>())
                {
                    hitObject.SendMessage("PlayerDamageTaken", DamageAmount);
                }
                if (hitObject.GetComponent<TurretEnergyPylon>())
                {
                    hitObject.SendMessage("OnDamageApplied", DamageAmount);

                }
            }


        }
    }

    void Explode()
    {
        Instantiate(explosionGO, transform.position, transform.rotation);
        source.PlayOneShot(source.clip);
       
        Destroy(gameObject, 2f);
    }


}
