using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TurretController : MonoBehaviour, IDamageable<float>
{
    public EnemyShield myShield;
    public List<TurretShield> GetActiveTurretShields = new List<TurretShield>();
    public List<TurretShield> GetDisabledTurretShields = new List<TurretShield>();
    private ID_BossHealthBar GetBossHealthBar;
    private Sequence bossHealthEnableSequence;
    private int MaxShieldCount = 0;

    public float CurrentHealth = 0.0f;
    public float MaxHealth = 400.0f;
    public bool bIsDead = false;
    private bool bIsShieldDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        myShield = GetComponentInChildren<EnemyShield>();
        MaxShieldCount = GetActiveTurretShields.Count;
        GetBossHealthBar = GetComponentInChildren<ID_BossHealthBar>();
        InitEnableSequence();
    }

    void InitEnableSequence()
    {
        bossHealthEnableSequence = DOTween.Sequence();
        //bossHealthEnableSequence.PrependInterval(1);
        bossHealthEnableSequence.Append(GetBossHealthBar.transform.DOScaleX(0, 1));
        bossHealthEnableSequence.PrependInterval(1);
        bossHealthEnableSequence.Append(GetBossHealthBar.transform.DOScaleX(1, 1));
        bossHealthEnableSequence.Play();
    }


    public void CheckShield(TurretShield hitShield)
    {

        if (!bIsShieldDisabled)
        {
            if (GetActiveTurretShields.Contains(hitShield))
            {
                if (hitShield.bIsDisabled)
                {
                    GetActiveTurretShields.Remove(hitShield);
                    GetDisabledTurretShields.Add(hitShield);

                }


            }
        }
        if (GetActiveTurretShields.Count <= 0)
        {
            bIsShieldDisabled = false;
            myShield.SendMessage("ToggleShieldStatus", false);
        }
        if (GetDisabledTurretShields.Count <= 0)
        {
            bIsShieldDisabled = true;
            myShield.SendMessage("ToggleShieldStatus", true);
        }

        if (bIsShieldDisabled)
        {
            if (GetDisabledTurretShields.Contains(hitShield))
            {
                if (!hitShield.bIsDisabled)
                {
                    GetDisabledTurretShields.Remove(hitShield);
                    GetActiveTurretShields.Add(hitShield);

                }

            }
        }



        // if (bIsShieldDisabled)
        // {
        //     myShield.bEnableShield = false;
        //     myShield.SendMessage("ToggleShieldStatus");
        // }
        // else
        // {
        //     myShield.bEnableShield = true;
        //     myShield.SendMessage("ToggleShieldStatus");
        // }
    }

    public void OnDamageApplied(float damageTaken)
    {
        CurrentHealth -= damageTaken;
        GetBossHealthBar.healthBar.fillAmount = CurrentHealth / MaxHealth;
        if (CurrentHealth < 0)
        {
            Debug.Log("I have been DEFEATED!");
            bIsDead = true;
        }

        //TODO: When attacked, rotate to face target
    }
}
