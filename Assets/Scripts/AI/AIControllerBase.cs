using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIControllerBase : MonoBehaviour
{
    private Enemy myEnemy;
    public NavAgent myNavAgent;
    public NavMeshAgent myNavMeshAgent;

    public float DistanceRemaining;
    void Awake() 
    {
        myEnemy = GetComponentInParent<Enemy>();
        myNavAgent = GetComponentInParent<NavAgent>();  
        myNavMeshAgent = GetComponentInParent<NavMeshAgent>();  
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
