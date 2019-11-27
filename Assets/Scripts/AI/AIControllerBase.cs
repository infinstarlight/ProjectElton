using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIControllerBase : MonoBehaviour
{
    private Enemy myEnemy;
    public NavAgent myNavAgent;
    public NavMeshAgent myNavMeshAgent;
    public GameObject AIEyes;
    private float nextFire;
    public float visionPollRate;
    public float visionRange;
    private RaycastHit visionHit;
    public bool bIsPlayerVisible = false;
    private Player GetPlayer;
    public bool bIsHumanoid = false;

    public float DistanceRemaining;
    public void Awake()
    {
        myEnemy = GetComponentInParent<Enemy>();
        if (bIsHumanoid)
        {
            myNavAgent = GetComponentInParent<NavAgent>();
            myNavMeshAgent = GetComponentInParent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        VisionRaycast();
    }

    public void VisionRaycast()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + visionPollRate;
            Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f);
            Ray visionRay = new Ray(AIEyes.transform.position, AIEyes.transform.forward);

            Debug.DrawRay(visionRay.origin, visionRay.direction * visionRange, Color.cyan);

            if (Physics.Raycast(visionRay, out visionHit, visionRange))
            {
                if (visionHit.collider)
                {
                    //Debug.Log("Hit: " + visionHit.collider.gameObject.name);

                }
                if (visionHit.collider.gameObject.GetComponent<Player>())
                {
                    GetPlayer = visionHit.collider.gameObject.GetComponent<Player>();
                    bIsPlayerVisible = true;
                    myEnemy.gameObject.transform.LookAt(GetPlayer.transform.position);
                }
                else
                {
                    bIsPlayerVisible = false;
                    if (GetPlayer)
                    {
                        GetPlayer = null;
                    }
                    if (bIsHumanoid)
                    {
                        if (myNavAgent.bIsTrackingPlayer)
                        {
                            myNavAgent.bIsTrackingPlayer = false;

                        }
                    }




                }
            }

        }
    }


}
