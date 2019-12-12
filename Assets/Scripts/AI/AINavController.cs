using UnityEngine.AI;
using UnityEngine;
using UnityEngine.Events;
public class AINavController : MonoBehaviour, ITracker
{
    public NavAgent myNavAgent;
    public NavMeshAgent myNavMeshAgent;
    private NavPoint playerNavPoint;
    public float DistanceRemaining;
    private AIControllerBase myAICon;
    public UnityEvent trackPlayerEvent = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        myAICon = GetComponentInParent<AIControllerBase>();
        myNavAgent = GetComponentInParent<NavAgent>();
        myNavMeshAgent = GetComponentInParent<NavMeshAgent>();
        trackPlayerEvent.AddListener(OnTrackTarget);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerNavPoint)
        {
            playerNavPoint = FindObjectOfType<Player>().gameObject.GetComponentInChildren<NavPoint>();
        }
    }

    public void OnTrackTarget()
    {
        if (myAICon)
        {
            myNavAgent.bIsTrackingPlayer = true;
            if (!myNavAgent.myNavPoints.Contains(playerNavPoint))
            {
                myNavAgent.myNavPoints.Add(playerNavPoint);
            }
            myNavMeshAgent.SetDestination(playerNavPoint.transform.position);
        }


    }
}
