using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartScript : MonoBehaviour
{
    private SpriteRenderer mySprite;

    void Awake()
    {
        var PlayerGO = Resources.Load<GameObject>("Characters/Player/PlayerCharacter") as GameObject;
        Instantiate(PlayerGO, transform.position, transform.rotation);
        var PlayerUIGO = Resources.Load<GameObject>("Characters/Player/PlayerUI") as GameObject;
        Instantiate(PlayerUIGO);
        mySprite = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        mySprite.enabled = false;
    }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}
