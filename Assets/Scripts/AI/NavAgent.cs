using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Rigidbody),typeof(NavMeshAgent))]
public class NavAgent : MonoBehaviour
{

    [SerializeField] NavPoint[] navPoints;

    NavMeshAgent myNavAgent;
    Vector3 newTravelPosition;

    //
    public int NavIndex = 0;

    // Use this for initialization
    void Start()
    {
        myNavAgent = GetComponent<NavMeshAgent>();
        FindDestination();
        //Debug.Log(navPoints.Length);
    }



    void FindDestination()
    {
        newTravelPosition = navPoints[NavIndex].transform.position;
        myNavAgent.SetDestination(newTravelPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        ++NavIndex;

        if (NavIndex >= navPoints.Length)
        {
            NavIndex = 0;
        }
            

        FindDestination();
    }
}
