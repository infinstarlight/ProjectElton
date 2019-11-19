using UnityEngine.SceneManagement;
using UnityEngine;

public class ID_PlayerUI : MonoBehaviour
{
    private static ID_PlayerUI instance = null;
    public static ID_PlayerUI Instance { get { return instance; } }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // In first scene, make us the singleton.
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
        }

    }
}
