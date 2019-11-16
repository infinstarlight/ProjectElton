using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SceneFadeTransition : MonoBehaviour
{
    public Animator myAnimator;
    private int nextLevelIndexToLoad;
    public string nextLevelName = "";
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        //DontDestroyOnLoad(this);
        myAnimator.ResetTrigger("ShouldFadeOut");
        myAnimator.SetTrigger("ShouldFadeIn");
    }

    // void Update()
    // {
    //     if (Keyboard.current.spaceKey.wasPressedThisFrame)
    //     {
    //     Debug.LogWarning("Testing fade to next level!");
    //      FadeToNextLevel();
            
    //     }
    // }

    public void FadeToLevelByString()
    {
        StartCoroutine(LoadAsyncSceneByString(nextLevelName));
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
           // Use a coroutine to load the Scene in the background
        StartCoroutine(LoadAsyncSceneByIndex());
        //SceneManager.LoadScene(nextLevelIndexToLoad);
    }

    IEnumerator LoadAsyncSceneByString(string newScene)
    {
        //The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newScene);

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

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
