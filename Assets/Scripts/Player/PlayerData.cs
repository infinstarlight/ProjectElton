using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public float health;
    public float[] position;
    public string lastSceneName;
    public DateTime GetDateTime;

    public PlayerData(Player player)
    {
       health = player.characterStats.CurrentHealth;
       lastSceneName = SceneManager.GetActiveScene().name;
       GetDateTime = DateTime.Now.Date;
       
       position = new float[3]; 
       position[0] = player.transform.position.x;
       position[1] = player.transform.position.y;
       position[2] = player.transform.position.z;
    }

  
    
}
