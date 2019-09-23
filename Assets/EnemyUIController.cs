using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyUIController : MonoBehaviour
{
    private ID_EnemyHealthBar healthBar;
    public GameObject BarPrefab;
    protected Slider Bar;
    public GameObject[] enemies;
    private Camera PlayerCamera;
    public Vector3 BarLocationMod = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera = Camera.main;
        for(int i = 0; i < enemies.Length; i++)
        {
            Bar = Instantiate(BarPrefab,FindObjectOfType<Canvas>().transform).GetComponent<Slider>();
        }
        
        healthBar = GetComponentInChildren<ID_EnemyHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar != null) 
        {
            if(Bar.value <= 0)
            {
                Destroy(this,1f);
            }
        }
    }

    void LateUpdate()
    {
        if(healthBar != null)
        {
        healthBar.healthBarGO.transform.position = PlayerCamera.WorldToScreenPoint(transform.position + BarLocationMod);
        }
        
    }
}
