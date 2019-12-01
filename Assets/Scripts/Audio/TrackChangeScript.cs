using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackChangeScript : MonoBehaviour
{
    private BGM_Player GetBGMPlayer;
    public bool bShouldLoop = false;
    // Start is called before the first frame update
    void Start()
    {
        GetBGMPlayer = FindObjectOfType<BGM_Player>();
    }

   private void OnTriggerEnter(Collider other) 
   {
        if(other.gameObject)
        {
            if(other.gameObject.GetComponent<Player>())
            {
                GetBGMPlayer.SendMessage("PlayNextTrack");
                if(bShouldLoop)
                {
                    GetBGMPlayer.SendMessage("ToggleLoop",true);
                }
            }
        }    
   }
}
