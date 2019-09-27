using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
public class NavAgent : MonoBehaviour
{

    [SerializeField] public NavPoint[] navPoints;
    public List<NavPoint> myNavPoints = new List<NavPoint>();

    NavMeshAgent myNavAgent;
    Vector3 newTravelPosition;

    [SerializeField]
    private int NavIndex = 0;
    private int index;

    // Use this for initialization
    void Start()
    {
        myNavAgent = GetComponent<NavMeshAgent>();
        FindDestination();
        //Debug.Log(navPoints.Length);
        index = myNavPoints.Count;
        
        
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
