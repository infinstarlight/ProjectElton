using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public float health;
    public float[] position;
    //public GameObject[] weaponArray;

    public PlayerData(Player player)
    {
       health = player.characterStats.CurrentHealth;
       
       position = new float[3]; 
       position[0] = player.transform.position.x;
       position[1] = player.transform.position.y;
       position[2] = player.transform.position.z;
    //    weaponArray = new GameObject[3];
    //    weaponArray = player.pCon.combatController.Weapons;
    }
    
}
