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
    private GameInstance GetGameInstance;
    public float SceneChangeDelay = 3.0f;
    public void Start()
    {
        GetSceneFade = FindObjectOfType<SceneFadeTransition>();
        SceneManager.activeSceneChanged += ChangedActiveScene;
        GetGameInstance = FindObjectOfType<GameInstance>();
        if (NextSceneName == "MainMenu")
        {
            GetGameInstance.bIsReturningToMainMenu = true;
        }
    }

    IEnumerator TimeChangedScene()
    {
        print(Time.time + " seconds");
        yield return new WaitForSeconds(SceneChangeDelay);
        print(Time.time + " seconds");

        // call the event
        TimeChanged();
    }

    private void Update()
    {
        if (!GetSceneFade)
        {
            GetSceneFade = FindObjectOfType<SceneFadeTransition>();
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
        if (NextSceneName == "MainMenu")
        {
            GetGameInstance.bIsReturningToMainMenu = true;
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

        GetSceneFade.FadeToLevelByString(NextSceneName);
        //StartCoroutine(LoadAsyncSceneByString(NextSceneName));
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
            GetSceneFade.myAnimator.SetTrigger("ShouldFadeOut");
            //StartCoroutine(LoadAsyncSceneByString(NextSceneName));
        }

    }
}
