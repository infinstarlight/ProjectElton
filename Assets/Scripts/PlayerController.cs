using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool bIsGamePaused = false;
    public bool bEnableInput = true;
    public PlayerStateScript playerState;
    public GameObject PauseMenuGO;

    void Awake()
    {
         
    }

    // Start is called before the first frame update
    void Start()
    {
        playerState = GetComponentInChildren<PlayerStateScript>();
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
       
        PauseMenuGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            PauseGame();
        }

        if(PauseMenuGO == null)
        {
            PauseMenuGO = FindObjectOfType<ID_PauseMenu>().gameObject;
        }
    }

    public void PauseGame()
    {
        bIsGamePaused = !bIsGamePaused;
        if (bIsGamePaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0.0f;
            if (PauseMenuGO)
            {
                if (!PauseMenuGO.activeSelf)
                {
                    PauseMenuGO.SetActive(true);
                }
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1.0f;
            if (PauseMenuGO)
            {
                if (PauseMenuGO.activeSelf)
                {
                    PauseMenuGO.SetActive(false);
                }
            }
        }

    }
}
