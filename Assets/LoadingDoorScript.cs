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
    AsyncOperation sceneLoadOpertation;

    private bool bShouldLoadLastScene = false;
    private bool bIsSceneLoaded = false;

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
        yield return null;

        if (!bShouldLoadLastScene)
        {
            //Begin to load the Scene you specify
            sceneLoadOpertation = SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Additive);
        }
        else
        {
            sceneLoadOpertation = SceneManager.LoadSceneAsync(lastSceneName, LoadSceneMode.Additive);
        }

        //Don't let the Scene activate until you allow it to
        sceneLoadOpertation.allowSceneActivation = false;
        Debug.Log("Pro :" + sceneLoadOpertation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!sceneLoadOpertation.isDone)
        {
            //Output the current progress
            Debug.Log("Loading progress: " + (sceneLoadOpertation.progress * 100) + "%");

            // Check if the load has finished
            if (sceneLoadOpertation.progress >= 0.9f)
            {
                if (!bIsSceneLoaded)
                {
                    //Activate the Scene
                    sceneLoadOpertation.allowSceneActivation = true;
                    myAnimator.SetBool("bOpenDoor?", true);


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




    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                bShouldLoadLastScene = true;
                myAnimator.SetBool("bOpenDoor?", false);

                //SceneManager.UnloadSceneAsync(lastSceneName);
            }
        }
    }
}
