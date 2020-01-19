using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlActivator : MonoBehaviour
{

    public bool bShouldToggleInput = false;
    private GameObject playerGO;
    private Player player;
    InputSystemPlayerMovement GetInput;


    // Start is called before the first frame update
    void Start()
    {
        playerGO = FindObjectOfType<Player>().gameObject;
        player = playerGO.GetComponent<Player>();
        GetInput = playerGO.GetComponent<InputSystemPlayerMovement>();


    }

    private void OnTriggerStay(Collider other)
    {
        if (bShouldToggleInput)
        {
            //player.pCon.DisableGameInputEvent.Invoke();
            //            GetInput.ForceMove(Vector3.zero, 0, 0, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                if (bShouldToggleInput)
                {
                    GetInput.bPlayerControl = false;
                    GetInput.ForceMove(Vector3.zero, 0, 1, false);
                }

            }
        }
    }
}
