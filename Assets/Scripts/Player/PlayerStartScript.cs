using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartScript : Singleton<PlayerStartScript>
{
    private SpriteRenderer mySprite;
    private SaveManager GetSave;
    private GameObject GetPlayerGO;
    private Player GetPlayer;

    private void OnEnable()
    {
        GetPlayer = FindObjectOfType<Player>();
        if (!GetPlayer)
        {
            var PlayerGO = Resources.Load<GameObject>("Characters/Player/IS_PlayerCharacter") as GameObject;
            GetPlayerGO = Instantiate(PlayerGO, transform.position, transform.rotation);

        }
        else
        {
            Destroy(gameObject);
        }


        mySprite = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mySprite.enabled = false;
        //Destroy(this,1);
    }

}
