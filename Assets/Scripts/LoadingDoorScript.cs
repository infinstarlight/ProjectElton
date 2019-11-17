using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class LoadingDoorScript : MonoBehaviour
{
    private Animator myAnimator;
    private AudioSource GetAudio;
    public string nextSceneName = "";
    public string lastSceneName = "";
    public AudioClip[] doorSounds;
    AsyncOperation sceneLoadOperation;
    AsyncOperation sceneUnloadOperation;
    public bool bIsLocked = false;

    public bool bShouldLoadScene = false;

    private bool bShouldLoadLastScene = false;
    private bool bIsSceneLoaded = false;
    [SerializeField]
    public EAmmoType desiredAmmoType;
    protected bool bIsRightAmmoType = false;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        GetAudio = GetComponent<AudioSource>();

        //DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

        myAnimator.SetBool("bOpenDoor?", false);
        if (lastSceneName == "")
        {
            lastSceneName = SceneManager.GetActiveScene().name;
        }

    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(5.0f);

        if (!bShouldLoadLastScene)
        {
            //Begin to load the Scene you specify
            sceneLoadOperation = SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Additive);

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
            if (bShouldLoadScene)
            {
                StartCoroutine(LoadScene());
            }
            else
            {
                OpenDoor();
            }

        }
    }



    IEnumerator UnloadScene()
    {
        if (bShouldLoadScene)
        {
            yield return new WaitForSeconds(10.0f);
            sceneUnloadOperation = SceneManager.UnloadSceneAsync(lastSceneName, UnloadSceneOptions.None);

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

    }

    void OpenDoor()
    {
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
        if (bShouldLoadScene)
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
                if (bShouldLoadScene)
                {
                    if (SceneManager.GetSceneByName(nextSceneName) != SceneManager.GetActiveScene())
                    {
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextSceneName));
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
                bShouldLoadLastScene = true;
                CloseDoor();


            }
        }
    }
}
