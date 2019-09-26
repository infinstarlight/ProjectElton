using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadNextScene : MonoBehaviour
{
        public string NextSceneName = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.GetComponent<Player>())
        {
            SceneManager.LoadScene(NextSceneName);
        }
        
    }
}
