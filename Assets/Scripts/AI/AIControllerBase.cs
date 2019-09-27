using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIControllerBase : MonoBehaviour
{
    private Enemy myEnemy;
    public NavAgent myNavAgent;
    void Awake() 
    {
        myEnemy = GetComponentInParent<Enemy>();
        myNavAgent = GetComponentInParent<NavAgent>();    
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
