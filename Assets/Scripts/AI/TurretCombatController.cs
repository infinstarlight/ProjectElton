using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCombatController : MonoBehaviour
{
    public float visionPollRate = 0.0f;
    private float visionNextFire = 0.0f;
    private Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0.0f);
    public RaycastHit hit;
    public Ray weaponRay;
    public float visionRange = 100.0f;
    public GameObject projGO;
    private LineRenderer GetLine;
    // Start is called before the first frame update
    void Start()
    {
        GetLine = GetComponent<LineRenderer>();
        GetLine.enabled = false;
    }
    private void Update()
    {
        if (Time.time > visionNextFire)
        {
            visionNextFire = Time.time + visionPollRate;
            Fire();
        }
    }
    void Fire()
    {
        GameObject hitObject = null;
        weaponRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(weaponRay.origin, weaponRay.direction * visionRange, Color.red);


        if (Physics.Raycast(weaponRay, out hit, visionRange))
        {
            if (hit.collider)
            {
                GetLine.enabled = true;
                GetLine.SetPosition(0, weaponRay.origin);
                
                hitObject = hit.collider.gameObject;

                {
                    if (hitObject.GetComponent<Player>())
                    {
                        GetLine.SetPosition(1, hitObject.transform.position);
                        if (projGO)
                        {
                            Instantiate(projGO, transform.position, transform.rotation);
                        }
                    }
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
            Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, 50.0f);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * visionRange);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireSphere(transform.position + transform.forward * visionRange, 50.0f);
        }
    }


}

