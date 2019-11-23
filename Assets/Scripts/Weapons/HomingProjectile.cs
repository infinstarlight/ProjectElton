using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : Projectile
{
    public RaycastHit hit;
    public Ray weaponRay;
    public Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0.0f);
    private Camera playerCamera;
    [SerializeField]
    private float weaponRange = 150.0f;
    private Rigidbody myRigidbody;
    public float castRadius = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;
        myRigidbody = GetComponent<Rigidbody>();
    }



    private void FixedUpdate()
    {
        weaponRay = playerCamera.ViewportPointToRay(rayOrigin);
        GameObject hitObject = null;
        myRigidbody.AddForce(transform.forward * (hitForce));
        if (Physics.SphereCast(weaponRay.origin, castRadius, weaponRay.direction * weaponRange, out hit, weaponRange * 2))
        {
            if (hit.collider)
            {
                hitObject = hit.collider.gameObject;

                if (hitObject.GetComponent<Enemy>())
                {
                    myRigidbody.AddForce(hitObject.transform.forward * hitForce);
                }
            }
        }
    }
    void OnDrawGizmos()
    {
        if (hit.collider)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, castRadius);

        }

        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * weaponRange);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireSphere(transform.position + transform.forward * weaponRange, castRadius);
        }

    }
}
