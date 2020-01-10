using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlActivator : MonoBehaviour
{

    public bool bShouldToggleInput = false;
    public bool bIsPlayerActive = false;
    private GameObject playerGO;
    private Player player;
    InputSystemPlayerMovement GetInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // private void OnDisable()
    // {
    //     player.pCon.EnableGameInputEvent.Invoke();
    // }

    private void OnTriggerStay(Collider other)
    {
        if (bShouldToggleInput)
        {
            //player.pCon.DisableGameInputEvent.Invoke();
            GetInput.ForceMove(Vector3.zero, 0, 0, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                playerGO = other.gameObject;
                player = playerGO.GetComponent<Player>();
                GetInput = playerGO.GetComponent<InputSystemPlayerMovement>();
                if (bShouldToggleInput)
                {
                    player.pCon.DisableGameInputEvent.Invoke();
                    GetInput.ForceMove(Vector3.zero, 0, 0, false);
                }
                else
                {
                    player.pCon.EnableGameInputEvent.Invoke();
                }
            }
        }
    }
}
