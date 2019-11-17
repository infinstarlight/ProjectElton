using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSceneScript : MonoBehaviour
{
    public string SceneToLoad = "";
    private void Awake()
    {
        SceneManager.LoadScene(SceneToLoad,LoadSceneMode.Additive);
    }
}
