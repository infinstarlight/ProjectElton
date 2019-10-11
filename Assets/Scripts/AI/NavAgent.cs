using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
public class NavAgent : MonoBehaviour
{

    //[SerializeField] public NavPoint[] navPoints;
    public List<NavPoint> myNavPoints = new List<NavPoint>();

    public bool bIsTrackingPlayer = false;
    NavMeshAgent myNavAgent;
    Vector3 newTravelPosition;

    [SerializeField]
    private int NavIndex = 0;
    //private int index;

    // Use this for initialization
    void Start()
    {
        myNavAgent = GetComponent<NavMeshAgent>();
        FindDestination();
    }



    public void FindDestination()
    {
        if (!bIsTrackingPlayer)
        {
            newTravelPosition = myNavPoints[NavIndex].transform.position;
            myNavAgent.SetDestination(newTravelPosition);
        }
        //newTravelPosition = navPoints[NavIndex].transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.gameObject);
        ++NavIndex;

        if (NavIndex >= myNavPoints.Capacity)
        {
            NavIndex = 0;
        }
        FindDestination();
    }
}
