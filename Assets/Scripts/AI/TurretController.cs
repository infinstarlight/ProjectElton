using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TurretController : MonoBehaviour, IDamageable<float>
{
    public float CurrentHealth = 0.0f;
    public float MaxHealth = 400.0f;
    private float healthPercent;
    public EnemyShield myShield;
    public List<TurretEnergyPylon> GetActiveEnergyPylons = new List<TurretEnergyPylon>();
    public List<TurretEnergyPylon> GetDisabledEnergyPylons = new List<TurretEnergyPylon>();


    private int MaxShieldCount = 0;


    public bool bIsDead = false;
    public bool bHasShield = false;
    public bool bIsMajorEnemy = false;
    private bool bIsMainShieldDisabled = false;
    private TurretRotator GetRotator;

    private bool bIsRoomUnlocker = false;
    private EnemyRoomUnlocker GetRoomUnlocker;
    private ID_BossHealthBar GetBossHealthBar;
    private ID_BossNameText GetBossNameText;
    private Sequence bossHealthEnableSequence;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthPercent = CurrentHealth / MaxHealth;
        GetRotator = GetComponentInChildren<TurretRotator>();
        if (bIsRoomUnlocker)
        {
            GetRoomUnlocker = FindObjectOfType<EnemyRoomUnlocker>();
        }
        if (bIsMajorEnemy)
        {
            GetBossHealthBar = GetComponentInChildren<ID_BossHealthBar>();
            GetBossNameText = GetComponentInChildren<ID_BossNameText>();
            bossHealthEnableSequence = DOTween.Sequence();
        }
        if (bHasShield)
        {
            myShield = GetComponentInChildren<EnemyShield>();
            MaxShieldCount = GetActiveEnergyPylons.Count;
        }



    }

    private void Update()
    {
        ToggleShield();
    }

    void InitEnableSequence()
    {
        bossHealthEnableSequence.Append(GetBossHealthBar.transform.DOScaleX(0, 1));
        bossHealthEnableSequence.Append(GetBossNameText.textMaterial.DOFade(0, 1));
        bossHealthEnableSequence.PrependInterval(1);
        bossHealthEnableSequence.Append(GetBossHealthBar.transform.DOScaleX(1, 1));
        bossHealthEnableSequence.Append(GetBossNameText.textMaterial.DOFade(1, 1));

    }

    void PlayUISequence()
    {
        bossHealthEnableSequence.Play();
    }




    public void CheckPylon(TurretEnergyPylon hitPylon)
    {
        //If the object is valid
        if (hitPylon)
        {
            //If the turret shield is active
            if (!bIsMainShieldDisabled)
            {
                //If the pylon that was hit is disabled
                if (hitPylon.bIsDisabled)
                {
                    //And is currently listed as active
                    if (GetActiveEnergyPylons.Contains(hitPylon))
                    {
                        //Remove from active list
                        GetActiveEnergyPylons.Remove(hitPylon);
                        //And list as disabled
                        GetDisabledEnergyPylons.Add(hitPylon);
                    }
                }
                //If the pylon is reactivated
                if (!hitPylon.bIsDisabled)
                {
                    //And listed as disabled
                    if (GetDisabledEnergyPylons.Contains(hitPylon))
                    {
                        //Return to active list
                        GetActiveEnergyPylons.Add(hitPylon);
                        GetDisabledEnergyPylons.Remove(hitPylon);
                    }
                }
            }
            //If the turret shield is disabled
            if (bIsMainShieldDisabled)
            {
                //If the pylon that was hit is disabled
                if (hitPylon.bIsDisabled)
                {
                    //And listed as active
                    if (GetActiveEnergyPylons.Contains(hitPylon))
                    {
                        GetActiveEnergyPylons.Remove(hitPylon);
                        GetDisabledEnergyPylons.Add(hitPylon);
                    }
                }
                if (!hitPylon.bIsDisabled)
                {
                    if (GetDisabledEnergyPylons.Contains(hitPylon))
                    {
                        GetActiveEnergyPylons.Add(hitPylon);
                        GetDisabledEnergyPylons.Remove(hitPylon);
                    }
                }
            }
        }
    }
    // if (!bIsShieldDisabled)
    // {
    //     if (GetActiveTurretShields.Contains(hitShield))
    //     {
    //         if (hitShield.bIsDisabled)
    //         {
    //             GetActiveTurretShields.Remove(hitShield);
    //             if (!GetDisabledTurretShields.Contains(hitShield))
    //             {
    //                 GetDisabledTurretShields.Add(hitShield);
    //             }
    //             else
    //             {
    //                 if (!hitShield.bIsDisabled)
    //                 {

    //                     if (GetDisabledTurretShields.Contains(hitShield))
    //                     {
    //                         GetDisabledTurretShields.Remove(hitShield);
    //                     }
    //                     GetActiveTurretShields.Add(hitShield);
    //                 }
    //             }
    //         }
    //     }
    // }
    // if (bIsShieldDisabled)
    // {
    //     if (GetDisabledTurretShields.Contains(hitShield))
    //     {
    //         if (!hitShield.bIsDisabled)
    //         {
    //             GetDisabledTurretShields.Remove(hitShield);
    //             if (!GetActiveTurretShields.Contains(hitShield))
    //             {
    //                 GetActiveTurretShields.Add(hitShield);
    //             }
    //         }

    //     }
    //     else
    //     {
    //         if (hitShield.bIsDisabled)
    //         {

    //             if (GetActiveTurretShields.Contains(hitShield))
    //             {
    //                 GetActiveTurretShields.Remove(hitShield);
    //             }
    //             GetDisabledTurretShields.Add(hitShield);
    //         }
    //     }
    // }



    IEnumerator ShieldStatusUpdate()
    {
        yield return new WaitForSeconds(0.50f);

        ToggleShield();

    }

    void ToggleShield()
    {
        if (GetDisabledEnergyPylons.Count >= MaxShieldCount)
        {
            bIsMainShieldDisabled = true;
            myShield.SendMessage("ToggleShieldStatus", bIsMainShieldDisabled);
        }
        if (GetActiveEnergyPylons.Count >= MaxShieldCount)
        {
            bIsMainShieldDisabled = false;
            myShield.SendMessage("ToggleShieldStatus", bIsMainShieldDisabled);
        }
    }


    public void OnDamageApplied(float damageTaken)
    {
        CurrentHealth -= damageTaken;
        healthPercent = CurrentHealth / MaxHealth;
        GetBossHealthBar.healthBar.DOFillAmount(healthPercent, 0.5f);
        if (CurrentHealth < 0)
        {
            Debug.Log("I have been DEFEATED!");
            bIsDead = true;
            if (GetRoomUnlocker)
            {
                GetRoomUnlocker.SendMessage("UnlockRoom", bIsDead);
            }
        }

        //TODO: When attacked, rotate to face target
    }

    public void DamageProcessor(EAmmoType damageType)
    {
        switch (damageType)
        {
            case EAmmoType.Standard:
                {

                }
                break;
        }
    }
}
