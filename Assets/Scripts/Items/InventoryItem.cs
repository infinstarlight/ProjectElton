using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EInvItemType
{
    None,
    DoorKey,
    PuzzlePiece
}

public class InventoryItem : MonoBehaviour
{
    public EInvItemType myItemType;
    private Player myPlayer;
    public string itemName = "";
    // Start is called before the first frame update
    private void Start() 
    {
        myPlayer = FindObjectOfType<Player>();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject)
        {
            if(myPlayer.gameObject)
            {
                GameObject itemGO = Instantiate(gameObject,transform);
                myPlayer.SendMessage("AddItem",itemGO);
                Destroy(gameObject,1f);
            }
        }    
    }

}
