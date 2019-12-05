using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class SceneFadeTransition : MonoBehaviour
{
    public Animator myAnimator;
    private int nextLevelIndexToLoad;
    public string nextLevelName = "";

    public bool bIsAlternateLoad = false;
    private AsyncOperation asyncLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.ResetTrigger("ShouldFadeOut");
        myAnimator.SetTrigger("ShouldFadeIn");
        StopCoroutine(LoadAsyncSceneByString(nextLevelName));
    }

    public void FadeToLevelByString(string newScene)
    {
        if (!bIsAlternateLoad)
        {
            bIsAlternateLoad = true;
        }
        myAnimator.ResetTrigger("ShouldFadeIn");

        StartCoroutine(LoadAsyncSceneByString(newScene));
        myAnimator.SetTrigger("ShouldFadeOut");

    }
    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int sceneIndex)
    {
        nextLevelIndexToLoad = sceneIndex;
        myAnimator.SetTrigger("ShouldFadeOut");
    }

    public void OnFadeComplete()
    {
        myAnimator.ResetTrigger("ShouldFadeOut");
        myAnimator.SetTrigger("ShouldFadeIn");
    }

    IEnumerator LoadAsyncSceneByString(string newSceneName)
    {
        //The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        asyncLoad = SceneManager.LoadSceneAsync(newSceneName,LoadSceneMode.Single);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadAsyncSceneByIndex()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
