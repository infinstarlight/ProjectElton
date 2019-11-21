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
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
