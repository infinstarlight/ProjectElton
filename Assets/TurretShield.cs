using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShield : MonoBehaviour, IDamageable<float>
{
    public float CurrentHealth = 0.0f;
    public float MaxHealth = 5.0f;

    private TurretController GetTurret;
    public bool bIsDisabled = false;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        GetTurret = FindObjectOfType<TurretController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsDisabled)
        {
            StartCoroutine(RegenHealth());
        }

    }

    public void OnDamageApplied(float damageTaken)
    {
        CurrentHealth -= damageTaken;
        if (CurrentHealth <= 0)
        {
            GetTurret.CheckShield(this);
            //GetTurret.myShield.SendMessage("ToggleShieldStatus");
            bIsDisabled = true;
        }
    }

    IEnumerator RegenHealth()
    {
        yield return new WaitForSeconds(30f);
        if (bIsDisabled)
        {
            ++CurrentHealth;
            if (CurrentHealth >= MaxHealth)
            {
                StopCoroutine(RegenHealth());
                bIsDisabled = false;
                GetTurret.CheckShield(this);
            }
        }

    }
}
