using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSceneScript : MonoBehaviour
{
    public string SceneToLoad = "";
    private void Awake()
    {
        if(!SceneManager.GetSceneByName(SceneToLoad).isLoaded)
        {
            SceneManager.LoadScene(SceneToLoad,LoadSceneMode.Additive);
        }
        
    }
}
