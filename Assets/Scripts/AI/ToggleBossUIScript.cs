using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBossUIScript : MonoBehaviour
{
    public GameObject bossGO;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                if(bossGO)
                {
                    bossGO.SendMessage("PlayUISequence");
                }
            }
        }
    }
}
