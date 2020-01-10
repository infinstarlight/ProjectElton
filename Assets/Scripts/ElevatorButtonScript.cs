using UnityEngine.Playables;
using UnityEngine;

public class ElevatorButtonScript : MonoBehaviour, IInteractable
{
    private bool bActivateElevator = false;
    private PlayableDirector myDirector;
    private InputSystemPlayerMovement GetInput;
    private Player GetPlayer;
    private PlayerControlActivator GetActivator;

    // Start is called before the first frame update
    void Start()
    {
        myDirector = GetComponentInParent<PlayableDirector>();
        GetInput = FindObjectOfType<InputSystemPlayerMovement>();
        GetActivator = GetComponentInChildren<PlayerControlActivator>();
        GetPlayer = FindObjectOfType<Player>();

    }

    private void Update()
    {
        if (myDirector.state == PlayState.Paused)
        {
            ToggleInput();
        }
    }


    void ToggleInput()
    {
        GetPlayer.pCon.EnableGameInputEvent.Invoke();
    }

    public void OnInteract()
    {
        bActivateElevator = !bActivateElevator;
        if (bActivateElevator)
        {
            myDirector.Play();
        }
    }
}
