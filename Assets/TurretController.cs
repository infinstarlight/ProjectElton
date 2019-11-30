using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour, IDamageable<float>
{
    public EnemyShield myShield;
    public List<TurretShield> GetActiveTurretShields = new List<TurretShield>();
    public List<TurretShield> GetDisabledTurretShields = new List<TurretShield>();
    private int MaxShieldCount = 0;

    public float CurrentHealth = 0.0f;
    public float MaxHealth = 400.0f;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        myShield = GetComponentInChildren<EnemyShield>();
        MaxShieldCount = GetActiveTurretShields.Count;
        //StartCoroutine(CheckShieldStatus());
    }


    IEnumerator CheckShieldStatus()
    {
        // TurretShield hitShield;
        yield return new WaitForSeconds(2f);
        //CheckShield();


    }

    public void AddShield(TurretShield hitShield)
    {
        if (GetDisabledTurretShields.Contains(hitShield))
        {
            if (!hitShield.bIsDisabled)
            {
                GetActiveTurretShields.Add(hitShield);
                GetDisabledTurretShields.Remove(hitShield);
            }
        }
        if (GetActiveTurretShields.Capacity >= MaxShieldCount)
        {
            myShield.bEnableShield = true;
            myShield.SendMessage("ToggleShieldStatus");
        }
    }

    public void RemoveShield(TurretShield hitShield)
    {
        if (GetActiveTurretShields.Contains(hitShield))
        {
            if (hitShield.bIsDisabled)
            {
                GetDisabledTurretShields.Add(hitShield);
                GetActiveTurretShields.Remove(hitShield);
            }
        }
        if (GetDisabledTurretShields.Capacity >= MaxShieldCount)
        {
            myShield.bEnableShield = false;
            myShield.SendMessage("ToggleShieldStatus");
        }
    }

    public void CheckShield(TurretShield hitShield)
    {
        if (GetActiveTurretShields.Contains(hitShield))
        {
            if (hitShield.bIsDisabled)
            {
                GetDisabledTurretShields.Add(hitShield);
                GetActiveTurretShields.Remove(hitShield);
            }
            if (GetActiveTurretShields.Count >= MaxShieldCount)
            {
                myShield.bEnableShield = true;
                myShield.SendMessage("ToggleShieldStatus");
            }
        }

        if (GetDisabledTurretShields.Contains(hitShield))
        {
            if (!hitShield.bIsDisabled)
            {
                GetActiveTurretShields.Add(hitShield);
                GetDisabledTurretShields.Remove(hitShield);
            }
            if (GetDisabledTurretShields.Count >= MaxShieldCount)
            {
                myShield.bEnableShield = false;
                myShield.SendMessage("ToggleShieldStatus");
            }
        }

    }

    public void OnDamageApplied(float damageTaken)
    {
        CurrentHealth -= damageTaken;
        if (CurrentHealth < 0)
        {
            Debug.Log("I have been DEFEATED!");
        }
    }
}
