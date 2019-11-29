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
                myPlayer.SendMessage("AddItem",this);
            }
        }    
    }

}
