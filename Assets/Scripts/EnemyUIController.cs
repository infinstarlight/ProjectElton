using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyUIController : MonoBehaviour
{
    private ID_EnemyHealthBar healthBar;
    public GameObject BarPrefab;
    protected Slider Bar;
    private Camera PlayerCamera;
    public Vector3 BarLocationMod = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera = Camera.main;
        Bar = BarPrefab.GetComponent<Slider>();
        healthBar = BarPrefab.GetComponent<ID_EnemyHealthBar>();


    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
        {
            if(PlayerCamera)
            {
                transform.LookAt(Camera.main.transform);
            }
            
            if (Bar.value <= 0)
            {
               // Destroy(this, 1f);
            }
        }
    }

    void LateUpdate()
    {
        if (healthBar != null)
        {
           
        }

    }
}
