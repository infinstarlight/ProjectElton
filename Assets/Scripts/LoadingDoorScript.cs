using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class LoadingDoorScript : MonoBehaviour
{
    private Animator myAnimator;
    private AudioSource GetAudio;
    public string newSceneName = "";
    public string lastSceneName = "";
    public AudioClip[] doorSounds;
    AsyncOperation sceneLoadOperation;
    AsyncOperation sceneUnloadOperation;
    public bool bIsLocked = false;

    public bool bShouldLoadNewScene = false;

    private bool bShouldLoadLastScene = false;
    private bool bIsSceneLoaded = false;
    [SerializeField]
    public EAmmoType desiredAmmoType;
    protected bool bIsRightAmmoType = false;
    private string colorName = "Color_ED482798";
    private MeshRenderer GetRenderer;
    public Color openDoorColor;
    private Color startColor;
    private float colorChangeValue = 0.0f;
    private bool bIsOpening = false;
    private ID_LoadDoor GetDoor;
    public UnityEvent doorOpenEvent = new UnityEvent();
    public UnityEvent doorCloseEvent = new UnityEvent();
    public UnityEvent doorUnlockEvent = new UnityEvent();

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        GetAudio = GetComponent<AudioSource>();
        GetDoor = GetComponentInChildren<ID_LoadDoor>();
        GetRenderer = GetDoor.gameObject.GetComponent<MeshRenderer>();
        startColor = GetRenderer.material.GetColor(colorName);
        //DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        doorOpenEvent.AddListener(OpenDoor);
        doorCloseEvent.AddListener(CloseDoor);
        doorUnlockEvent.AddListener(UnlockDoor);
        myAnimator.SetBool("bOpenDoor?", false);
        if (lastSceneName == "")
        {
            lastSceneName = SceneManager.GetActiveScene().name;
        }

    }

    private void OnDisable()
    {
        doorOpenEvent.RemoveAllListeners();
        doorCloseEvent.RemoveAllListeners();
        doorUnlockEvent.RemoveAllListeners();
    }


    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(5.0f);

        if (!bShouldLoadLastScene)
        {
            //Begin to load the Scene you specify
            sceneLoadOperation = SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Additive);

        }
        else
        {
            sceneLoadOperation = SceneManager.LoadSceneAsync(lastSceneName, LoadSceneMode.Additive);
        }
        if (!bIsSceneLoaded)
        {
            //Don't let the Scene activate until you allow it to
            sceneLoadOperation.allowSceneActivation = false;
            Debug.Log("Pro :" + sceneLoadOperation.progress);
            //When the load is still in progress, output the Text and progress bar
            while (!sceneLoadOperation.isDone)
            {
                //Output the current progress
                Debug.Log("Loading progress: " + (sceneLoadOperation.progress * 100) + "%");

                // Check if the load has finished
                if (sceneLoadOperation.progress >= 0.9f)
                {

                    //Activate the Scene
                    sceneLoadOperation.allowSceneActivation = true;
                    OpenDoor();
                    bIsSceneLoaded = true;

                }

                yield return null;
            }
        }


    }

    public void CheckAmmoType(EAmmoType hitAmmoType)
    {
        if (hitAmmoType == desiredAmmoType)
        {
            bIsRightAmmoType = true;
        }

        if (bIsRightAmmoType)
        {
            if (bShouldLoadNewScene || bShouldLoadLastScene)
            {
                StartCoroutine(LoadScene());
            }
            else
            {

                GetRenderer.material.SetColor(colorName, openDoorColor);
                OpenDoor();
            }

        }
    }



    IEnumerator UnloadScene()
    {
        yield return new WaitForSeconds(5.0f);
        if (!bShouldLoadLastScene)
        {
            sceneUnloadOperation = SceneManager.UnloadSceneAsync(newSceneName, UnloadSceneOptions.None);
        }
        else
        {
            sceneUnloadOperation = SceneManager.UnloadSceneAsync(lastSceneName, UnloadSceneOptions.None);

        }
        while (!sceneUnloadOperation.isDone)
        {
            Debug.Log("Unloading progress: " + (sceneUnloadOperation.progress * 100) + "%");
            if (sceneUnloadOperation.progress >= 0.9f)
            {
                CloseDoor();
            }
            yield return null;
        }
    }



    void OpenDoor()
    {
        bIsOpening = true;
        if (!bIsLocked)
        {
            myAnimator.SetBool("bOpenDoor?", true);
        }
        else
        {
            GetAudio.clip = doorSounds[2];
            GetAudio.PlayOneShot(GetAudio.clip);
        }

    }

    void CloseDoor()
    {
        myAnimator.SetBool("bOpenDoor?", false);
        bIsOpening = false;
        if (bShouldLoadNewScene)
        {
            StopCoroutine(UnloadScene());
        }

    }

    public void OnDoorOpen()
    {
        GetAudio.clip = doorSounds[0];
        GetAudio.PlayOneShot(GetAudio.clip);

    }

    public void OnDoorClose()
    {
        GetAudio.clip = doorSounds[1];
        GetAudio.PlayOneShot(GetAudio.clip);
        GetRenderer.material.SetColor(colorName, startColor);
        if (bIsSceneLoaded)
        {
            bIsSceneLoaded = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                if (bShouldLoadNewScene)
                {
                    if (SceneManager.GetSceneByName(newSceneName) != SceneManager.GetActiveScene())
                    {
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName(newSceneName));
                    }
                }
                else
                {
                    if (SceneManager.GetSceneByName(lastSceneName) != SceneManager.GetActiveScene())
                    {
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName(lastSceneName));
                    }
                }
                StopCoroutine(LoadScene());
                StartCoroutine(UnloadScene());
            }
        }
    }

    public void UnlockDoor()
    {
        if (bIsLocked)
        {
            bIsLocked = false;
            OpenDoor();
        }
    }

    public void OnChargerEvent()
    {
        UnlockDoor();
    }




    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                if (newSceneName != "")
                {
                    bShouldLoadNewScene = !bShouldLoadNewScene;
                    bShouldLoadLastScene = !bShouldLoadLastScene;
                }
                CloseDoor();
            }
        }
    }


}