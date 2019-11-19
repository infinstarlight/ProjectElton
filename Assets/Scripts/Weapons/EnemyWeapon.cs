using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : Weapon
{
    public AIControllerBase GetAICon;
    public GameObject AIEyes;
    // Start is called before the first frame update
    void Start()
    {
        weaponAudio = GetComponent<AudioSource>();
        gunEndGO = GetComponentInChildren<ID_gunEnd>().gameObject;
        GetAICon = GetComponentInParent<AIControllerBase>();
        AIEyes = GetAICon.AIEyes;
        aimGO = AIEyes;
        bIsPlayerWeapon = false;
    }


  public IEnumerator AIFire()
   {
       Fire();
       yield return fireRate;
   }
}
