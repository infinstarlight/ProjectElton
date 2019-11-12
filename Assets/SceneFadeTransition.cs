using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFadeTransition : MonoBehaviour
{
    public Animator myAnimator;
    private int nextLevelIndexToLoad;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        DontDestroyOnLoad(this);
        myAnimator.ResetTrigger("ShouldFadeOut");
        myAnimator.SetTrigger("ShouldFadeIn");
    }

    public void StartFade()
    {

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
        SceneManager.LoadScene(nextLevelIndexToLoad);
    }
}
