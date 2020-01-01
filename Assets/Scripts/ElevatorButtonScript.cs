using UnityEngine.Playables;
using UnityEngine;

public class ElevatorButtonScript : MonoBehaviour, IInteractable
{
    private bool bActivateElevator = false;
    private PlayableDirector myDirector;
    // Start is called before the first frame update
    void Start()
    {
        myDirector = GetComponentInParent<PlayableDirector>();
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
