using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private PlayerController pCon;
    private GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pCon = FindObjectOfType<PlayerController>();
        PauseMenu = FindObjectOfType<ID_PauseMenu>().gameObject;
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
}
