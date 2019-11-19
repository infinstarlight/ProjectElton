using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject spawnedObject = null;

    // Start is called before the first frame update
    void Start()
    {
       Instantiate(spawnedObject,transform.position,transform.rotation);
    }

   
}
