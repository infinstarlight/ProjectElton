using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
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
    public UnityEventWithFloat damageEvent = new UnityEventWithFloat();
    

    public void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
        source = GetComponent<AudioSource>();
    }


    public void OnDeath()
    {
        if (characterStats.bIsDead)
        {
            characterStats.bCanTakeDamage = false;
            source.clip = deathClip;
            source.PlayOneShot(source.clip);

            GameObject deathVX = Instantiate(DeathVFX, transform.position, transform.rotation);

            //TODO: Disable player input on death
        }

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
        

            if (characterStats.CurrentHealth <= 0)
            {
                characterStats.bIsDead = true;
                //OnDeath();
            }
        }
    }

}
