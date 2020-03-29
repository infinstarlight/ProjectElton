using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(AudioSource))]
public class Character : MonoBehaviour, IKillable, IDamageable<float>
{
    public CharacterStats characterStats;
    private AudioSource source;
    public AudioClip[] hurtClips;
    public AudioClip deathClip;

    public GameObject DeathVFX;

    public bool bShouldDestroyOnDeath;

    public float DestroyDelay = 2.0f;
    public float MovementMultiplier = 1.0f;
    public float MovementMultiplierMod = 0.0f;
    public UnityFloatEvent damageEvent = new UnityFloatEvent();
    public UnityEAmmoEvent damageProcessEvent = new UnityEAmmoEvent();


    public void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
        source = GetComponent<AudioSource>();
        damageProcessEvent.AddListener(DamageProcessor);
    }

    // private void Start()
    // {

    // }
    public void OnDeath()
    {
        if (characterStats.bIsDead)
        {
            characterStats.bCanTakeDamage = false;
            source.clip = deathClip;
            source.PlayOneShot(source.clip);

            GameObject deathVX = Instantiate(DeathVFX, transform.position, transform.rotation);
            if (bShouldDestroyOnDeath)
            {
                StartCoroutine(DestroyAfterDelay());
            }
            //TODO: Disable player input on death
        }

    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(DestroyDelay);
        Destroy(gameObject);
    }

    public void OnDamageApplied(float damageTaken)
    {
        if (characterStats.bCanTakeDamage)
        {
            characterStats.CurrentHealth -= damageTaken;
            if (hurtClips.Length > 0)
            {
                source.clip = hurtClips[Random.Range(0, hurtClips.Length)];
                source.PlayOneShot(source.clip);
            }
            characterStats.healthPercentage = characterStats.CurrentHealth / characterStats.MaxHealth;

            if (characterStats.CurrentHealth <= 0)
            {
                characterStats.bIsDead = true;
                //OnDeath();
            }
        }
    }

    public virtual void OnFreezeEvent()
    {
        StartCoroutine(FreezeTimer());
    }

    public void DamageProcessor(EAmmoType damageType)
    {
        switch (damageType)
        {
            case EAmmoType.Standard:
                {

                }
                break;
            case EAmmoType.Ice:
                {
                    if (MovementMultiplier >= 0)
                    {
                        MovementMultiplier -= MovementMultiplierMod;
                    }
                    if (MovementMultiplier <= 0)
                    {
                        OnFreezeEvent();
                    }
                }
                break;
        }
    }

    IEnumerator FreezeTimer()
    {
        while (MovementMultiplier < 1.0f)
        {
            MovementMultiplier += 0.01f;
            yield return new WaitForSeconds(0.50f);
        }
        if (MovementMultiplier >= 1.0f)
        {
            MovementMultiplier = 1.0f;
            StopCoroutine(FreezeTimer());
        }

        yield return null;
    }

}
