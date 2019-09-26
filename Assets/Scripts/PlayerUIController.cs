using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private PlayerController pCon;
    private GameObject PauseMenu;
    private ID_StyleSlider styleSliderScript;

    void Awake()
    {
        PauseMenu = pCon.PauseMenuGO;
    }
    // Start is called before the first frame update
    void Start()
    {
        pCon = FindObjectOfType<PlayerController>();

        styleSliderScript = FindObjectOfType<ID_StyleSlider>();
        //PauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (styleSliderScript != null)
        {
            styleSliderScript.styleSlider.value = pCon.playerState.StylePercent;
        }
       
    }

    public void UnpauseGame()
    {
        if (PauseMenu)
        {
            if (PauseMenu.activeSelf)
            {
                PauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1.0f;
            }
        }
    }

    public void RestartFromCheckpoint()
    {
        Debug.LogWarning("We don't have save data so this will restart the scene for now");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
