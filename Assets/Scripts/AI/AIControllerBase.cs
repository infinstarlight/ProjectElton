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

    public float DistanceRemaining;
    void Awake()
    {
        myEnemy = GetComponentInParent<Enemy>();
        myNavAgent = GetComponentInParent<NavAgent>();
        myNavMeshAgent = GetComponentInParent<NavMeshAgent>();
        AIEyes = GetComponentInChildren<ID_AI_Eyes>().gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {

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
                    bIsPlayerVisible = true;
                }
                else
                {
                    bIsPlayerVisible = false;

                }
            }

        }
    }


}
