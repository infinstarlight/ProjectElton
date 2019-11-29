using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomUnlocker : MonoBehaviour
{

    public List<Enemy> Enemies = new List<Enemy>();
    public LoadingDoorScript[] GetLoadingDoors;
    private bool bCanRoomUnlock = false;
  

    private void Update()
    {
        StartCoroutine(CheckRoomState());
        if (bCanRoomUnlock)
        {
            StopCoroutine(CheckRoomState());

            Destroy(gameObject, 2.0f);
        }
    }



    IEnumerator CheckRoomState()
    {
        yield return new WaitForSeconds(2.0f);
    
        for (int e = 0; e < Enemies.Count; ++e)
        {
            if (Enemies[e].GetComponent<CharacterStats>().bIsDead)
            {
                Enemies.Remove(Enemies[e]);

            }
        }

        if (Enemies.Count <= 0)
        {
            bCanRoomUnlock = true;
            for (int i = 0; i < GetLoadingDoors.Length; ++i)
            {
                GetLoadingDoors[i].UnlockDoor();

            }
        }
    }
}
