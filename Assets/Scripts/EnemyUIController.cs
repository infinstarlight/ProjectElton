using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyUIController : MonoBehaviour
{
    private ID_EnemyHealthBar healthBar;
    private ID_EnemyLockOnImage lockOnImage;
    private GameObject BarPrefab;
    private GameObject ImagePrefab;


    private Camera PlayerCamera;
    public Vector3 BarLocationMod = Vector3.up;
    public bool bIsTargeted = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera = Camera.main;
        BarPrefab = GetComponentInChildren<ID_EnemyHealthBar>().gameObject;
        healthBar = BarPrefab.GetComponent<ID_EnemyHealthBar>();
        ImagePrefab = GetComponentInChildren<ID_EnemyLockOnImage>().gameObject;
        lockOnImage = ImagePrefab.GetComponent<ID_EnemyLockOnImage>();
        ImagePrefab.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
        {
            if (PlayerCamera)
            {
                transform.LookAt(PlayerCamera.transform);
            }

            // if (Bar.value <= 0)
            // {
            //     // Destroy(this, 1f);
            // }
        }
        if (lockOnImage)
        {
            if (bIsTargeted)
            {
                ImagePrefab.SetActive(true);
                ImagePrefab.transform.LookAt(PlayerCamera.transform);
            }
            else
            {
                ImagePrefab.SetActive(false);
                //ImagePrefab.transform.LookAt(PlayerCamera.transform);
            }
        }

    }

    // void LateUpdate()
    // {
    //     if (healthBar != null)
    //     {

    //     }

    // }
}
