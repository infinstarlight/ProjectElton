using UnityEngine.Playables;
using UnityEngine;

public class ElevatorButtonScript : MonoBehaviour, IInteractable
{
    private bool bActivateElevator = false;
    private PlayableDirector myDirector;
    private InputSystemPlayerMovement GetInput;
    private Player GetPlayer;
    private PlayerControlActivator GetActivator;
    public GameObject GetAnchorPoint;
    public Vector3 playerNewPoint;
    [SerializeField]
    private bool bPlayerActive = false;


    // Start is called before the first frame update
    void Start()
    {
        myDirector = GetComponentInParent<PlayableDirector>();
        GetInput = FindObjectOfType<InputSystemPlayerMovement>();
        GetActivator = GetComponentInChildren<PlayerControlActivator>();
        GetPlayer = FindObjectOfType<Player>();
        GetAnchorPoint = GetComponentInChildren<ID_AnchorPoint>().gameObject;


    }

    private void Update()
    {
        if (bPlayerActive)
        {
            if (myDirector.state == PlayState.Paused)
            {
                EnableInput();

            }
            else
            {
                DisableInput();

                GetPlayer.transform.position = GetAnchorPoint.transform.position;
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                bPlayerActive = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!bPlayerActive)
        {
            GetPlayer.transform.position = playerNewPoint;
        }
    }


    void EnableInput()
    {
        GetPlayer.pCon.EnableGameInputEvent.Invoke();

    }

    void DisableInput()
    {
        GetPlayer.pCon.DisableGameInputEvent.Invoke();
    }

    public void OnInteract()
    {
        bActivateElevator = !bActivateElevator;
        if (bActivateElevator)
        {
            //myDirector.
            myDirector.Play();
        }
    }
}
