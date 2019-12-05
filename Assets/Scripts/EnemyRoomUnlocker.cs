using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomUnlocker : MonoBehaviour
{

    public List<Enemy> Enemies = new List<Enemy>();
    public List<GameObject> otherEnemies = new List<GameObject>();
    public LoadingDoorScript[] GetLoadingDoors;
    private bool bCanRoomUnlock = false;

    private void Start()
    {

        for (int i = 0; i < GetLoadingDoors.Length; ++i)
        {
            GetLoadingDoors[i].doorLockEvent.Invoke();

        }
    }


    private void Update()
    {
        StartCoroutine(CheckRoomState());
        if (bCanRoomUnlock)
        {
            StopCoroutine(CheckRoomState());

            Destroy(gameObject, 4.0f);
        }
    }

    void UnlockRoom(bool bCanUnlock)
    {
        if (bCanUnlock)
        {
            for (int i = 0; i < GetLoadingDoors.Length; ++i)
            {
                GetLoadingDoors[i].doorUnlockEvent.Invoke();

            }
        }
    }



    IEnumerator CheckRoomState()
    {
        yield return new WaitForSeconds(0.75f);

        if (Enemies.Count > 0)
        {
            for (int e = 0; e < Enemies.Count; ++e)
            {
                if (Enemies[e].GetComponent<CharacterStats>().bIsDead)
                {
                    Enemies.Remove(Enemies[e]);

                }
            }

        }

        if (otherEnemies.Count > 0)
        {
            for (int o = 0; o < otherEnemies.Count; ++o)
            {
                if (otherEnemies[o].GetComponent<TurretController>().bIsDead)
                {
                    bCanRoomUnlock = true;
                    for (int i = 0; i < GetLoadingDoors.Length; ++i)
                    {
                        GetLoadingDoors[i].doorUnlockEvent.Invoke();

                    }
                }
            }
        }

        if (Enemies.Count <= 0)
        {
            bCanRoomUnlock = true;
            for (int i = 0; i < GetLoadingDoors.Length; ++i)
            {
                UnlockRoom(bCanRoomUnlock);

            }
        }
    }
}
