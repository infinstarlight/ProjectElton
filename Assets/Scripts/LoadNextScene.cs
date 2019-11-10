using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadNextScene : MonoBehaviour
{
    public string NextSceneName = "";
    public delegate void Change();
    public static event Change TimeChanged;
    public float SceneChangeDelay = 3.0f;
    public void Start()
    {
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
        SceneManager.LoadScene(NextSceneName);

        Scene scene = SceneManager.GetSceneByName(NextSceneName);
        SceneManager.SetActiveScene(scene);
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
            // wait 1.5 seconds before change to Scene2
            StartCoroutine(TimeChangedScene());
            //SceneManager.LoadScene(NextSceneName);
        }

    }
}
