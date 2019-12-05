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
    private ID_BossNameText GetBossNameText;
    private Sequence bossHealthEnableSequence;

    private int MaxShieldCount = 0;

    public float CurrentHealth = 0.0f;
    public float MaxHealth = 400.0f;
    public bool bIsDead = false;
    private bool bIsShieldDisabled = false;
    private TurretRotator GetRotator;
    TurretShield[] ActiveShieldArray;
    TurretShield[] DisabledShieldArray;
    [SerializeField]
    private bool bIsRoomUnlocker = false;
    private EnemyRoomUnlocker GetRoomUnlocker;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        myShield = GetComponentInChildren<EnemyShield>();
        MaxShieldCount = GetActiveTurretShields.Count;
        GetBossHealthBar = GetComponentInChildren<ID_BossHealthBar>();
        GetBossNameText = GetComponentInChildren<ID_BossNameText>();
        bossHealthEnableSequence = DOTween.Sequence();
        GetRotator = GetComponentInChildren<TurretRotator>();
        InitEnableSequence();
        if (bIsRoomUnlocker)
        {
            GetRoomUnlocker = FindObjectOfType<EnemyRoomUnlocker>();
        }

    }

    void InitEnableSequence()
    {

        //bossHealthEnableSequence.PrependInterval(1);
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




    public void CheckShield(TurretShield hitShield)
    {
        ToggleShield();

        if (!bIsShieldDisabled)
        {
            if (GetActiveTurretShields.Contains(hitShield))
            {
                if (hitShield.bIsDisabled)
                {
                    GetActiveTurretShields.Remove(hitShield);
                    if (!GetDisabledTurretShields.Contains(hitShield))
                    {
                        GetDisabledTurretShields.Add(hitShield);
                    }

                }
            }
            else
            {
                if (!hitShield.bIsDisabled)
                {
                    if (GetDisabledTurretShields.Contains(hitShield))
                    {
                        GetDisabledTurretShields.Remove(hitShield);
                    }
                    GetActiveTurretShields.Add(hitShield);
                }
            }
        }
        if (bIsShieldDisabled)
        {
            if (GetDisabledTurretShields.Contains(hitShield))
            {
                if (!hitShield.bIsDisabled)
                {
                    GetDisabledTurretShields.Remove(hitShield);
                    if (!GetActiveTurretShields.Contains(hitShield))
                    {
                        GetActiveTurretShields.Add(hitShield);
                    }
                }

            }
            else
            {
                if (hitShield.bIsDisabled)
                {
                    if (GetActiveTurretShields.Contains(hitShield))
                    {
                        GetActiveTurretShields.Remove(hitShield);
                    }
                    GetDisabledTurretShields.Add(hitShield);
                }
            }
        }

    }

    void ToggleShield()
    {
        if (GetDisabledTurretShields.Count >= MaxShieldCount)
        {
            bIsShieldDisabled = true;
            myShield.SendMessage("ToggleShieldStatus", bIsShieldDisabled);
        }
        if (GetActiveTurretShields.Count >= MaxShieldCount)
        {
            bIsShieldDisabled = false;
            myShield.SendMessage("ToggleShieldStatus", bIsShieldDisabled);
        }
    }


    public void OnDamageApplied(float damageTaken)
    {
        CurrentHealth -= damageTaken;
        GetBossHealthBar.healthBar.fillAmount = CurrentHealth / MaxHealth;
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
}
