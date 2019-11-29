using UnityEngine.Playables;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    private Camera playerCamera;
    public PlayableDirector myDirector;
    private InputSystem_PlayerController GetPlayerController;
    public bool bHasPlayed = false;

    private void Awake()
    {
        playerCamera = Camera.main;
        GetPlayerController = FindObjectOfType<InputSystem_PlayerController>();
        if (myDirector)
        {
            myDirector.gameObject.SetActive(false);
            myDirector.stopped += OnCutSceneEnd;
        }
    }

    private void Start()
    {

    }

    void OnCutSceneEnd(PlayableDirector currentDirector)
    {
        if (myDirector == currentDirector)
        {
            //myDirector.enabled = false;
            playerCamera.enabled = true;
            GetPlayerController.EnableInputEvent.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                if (!bHasPlayed)
                {
                    myDirector.gameObject.SetActive(true);
                    //myDirector.enabled = true;
                    myDirector.Play();
                    GetPlayerController.DisableInputEvent.Invoke();
                    playerCamera.enabled = false;
                    bHasPlayed = true;
                }

            }
        }
    }


}
