﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartScript : MonoBehaviour
{
    private SpriteRenderer mySprite;
    private Player GetPlayer;
    private SaveManager GetSave;

    private void OnEnable()
    {
        GetPlayer = FindObjectOfType<Player>();
        GetSave = FindObjectOfType<SaveManager>();

        if (GetSave)
        {
            if (GetSave.bWasSaveLoaded)
            {
                GetSave.bWasSaveLoaded = false;
                Destroy(this);
            }
        }
        if (!GetPlayer)
        {
            var PlayerGO = Resources.Load<GameObject>("Characters/Player/IS_PlayerCharacter") as GameObject;
            Instantiate(PlayerGO, transform.position, transform.rotation);
            var PlayerUIGO = Resources.Load<GameObject>("Characters/Player/PlayerUI") as GameObject;
            Instantiate(PlayerUIGO);
        }
    }

    void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        mySprite.enabled = false;
    }

}
