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

    private bool bShouldLoadLastScene = false;
    private bool bIsSceneLoaded = false;
    [SerializeField]
    protected EAmmoType desiredAmmoType;
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
        lastSceneName = SceneManager.GetActiveScene().name;
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
                    myAnimator.SetBool("bOpenDoor?", true);
                    bIsSceneLoaded = true;

                }

                yield return null;
            }
        }


    }

    public void CheckAmmoType(EAmmoType hitAmmoType)
    {
        if(hitAmmoType == desiredAmmoType)
        {
            bIsRightAmmoType = true;
        }

        if(bIsRightAmmoType)
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator UnloadScene()
    {
        yield return new WaitForSeconds(10.0f);
        sceneUnloadOperation = SceneManager.UnloadSceneAsync(lastSceneName, UnloadSceneOptions.None);

        sceneUnloadOperation.allowSceneActivation = false;
        SceneManager.UnloadSceneAsync(lastSceneName);
        while (!sceneUnloadOperation.isDone)
        {
            Debug.Log("Loading progress: " + (sceneUnloadOperation.progress * 100) + "%");
            if (sceneUnloadOperation.progress >= 0.9f)
            {
                if (bIsSceneLoaded)
                {
                    sceneUnloadOperation.allowSceneActivation = true;
                }
            }
            yield return null;
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

        bIsSceneLoaded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                if (SceneManager.GetSceneByName(nextSceneName) != SceneManager.GetActiveScene())
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextSceneName));
                }
                StopCoroutine(LoadScene());
                StartCoroutine(UnloadScene());
            }
        }
    }




    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                bShouldLoadLastScene = true;
                myAnimator.SetBool("bOpenDoor?", false);
               StopCoroutine(UnloadScene());
                //StartCoroutine(UnloadScene());

            }
        }
    }
}
