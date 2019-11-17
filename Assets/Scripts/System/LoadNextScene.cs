using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadNextScene : MonoBehaviour
{
    public string NextSceneName = "";
    public delegate void Change();
    public static event Change TimeChanged;
    private SceneFadeTransition GetSceneFade;
    public float SceneChangeDelay = 3.0f;
    public void Start()
    {
        GetSceneFade = FindObjectOfType<SceneFadeTransition>();
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    IEnumerator TimeChangedScene()
    {
        print(Time.time + " seconds");
        yield return new WaitForSeconds(SceneChangeDelay);
        print(Time.time + " seconds");

        // call the event
        TimeChanged();
    }

    IEnumerator LoadAsyncSceneByString(string newSceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newSceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }

        Debug.Log("Scenes: " + currentName + ", " + next.name);
    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
        TimeChanged += ChangeScene;
    }

    void ChangeScene()
    {
        Debug.Log("Changing to the next Scene");
       StartCoroutine(LoadAsyncSceneByString(NextSceneName));
    }

    void OnDisable()
    {
        TimeChanged -= ChangeScene;
        Debug.Log("OnDisable happened for Scene1");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            // wait 3 seconds before change to Scene2
            StartCoroutine(TimeChangedScene());
            //StartCoroutine(LoadAsyncSceneByString(NextSceneName));
        }

    }
}
