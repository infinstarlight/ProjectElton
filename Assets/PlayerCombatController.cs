using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{

    public GameObject currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWeapon.GetComponent<PlayerWeapon>())
        {
            if(Input.GetButtonDown("Fire1"))
            {
                currentWeapon.GetComponent<PlayerWeapon>().Fire();
            }
        }
    }
}
