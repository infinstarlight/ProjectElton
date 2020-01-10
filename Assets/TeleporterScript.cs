using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour, IInteractable
{
    public Transform TeleportEndPoint;
    public GameObject playerGO;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnInteract()
    {


        playerGO.GetComponent<CharacterController>().enabled = false;
        playerGO.GetComponent<Rigidbody>().position = TeleportEndPoint.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                playerGO = other.gameObject;
                playerGO.transform.localPosition = TeleportEndPoint.localPosition;
                // playerGO.transform.rotation = TeleportEndPoint.rotation;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerGO = null;
    }
}
