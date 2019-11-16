using UnityEngine.SceneManagement;
using UnityEngine;

public class ID_PlayerUI : MonoBehaviour
{
    private static ID_PlayerUI instance = null;
    public static ID_PlayerUI Instance { get { return instance; } }

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
                return;
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(this);
            }

        }
    }
    void Start()
    {

    }
}
