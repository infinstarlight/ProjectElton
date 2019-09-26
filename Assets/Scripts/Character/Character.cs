using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(AudioSource))]
public class Character : MonoBehaviour,IKillable,IDamageable<float>
{
    public CharacterStats characterStats;
    private AudioSource source;
    public AudioClip[] hurtClips;
    public AudioClip deathClip;

    public GameObject DeathVFX;

    public bool bShouldDestroyOnDeath;

    public float DestroyDelay;

    void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


     public void OnDeath()
    {
        if(characterStats.bIsDead)
        {
            characterStats.bCanTakeDamage = false;
            source.clip = deathClip;
            source.PlayOneShot(source.clip);
            
            GameObject deathVX = Instantiate(DeathVFX,transform.position,transform.rotation);
            if(bShouldDestroyOnDeath)
            {
                Destroy(gameObject, DestroyDelay);
            }
            //TODO: Disable player input on death
        }
        
    }

    public void OnDamageApplied(float damageTaken)
    {
        if(characterStats.bCanTakeDamage)
        {
        characterStats.CurrentHealth -= damageTaken;
        source.clip = hurtClips[Random.Range(0, hurtClips.Length)];
        source.PlayOneShot(source.clip);
            if(characterStats.CurrentHealth <= 0)
            {
                characterStats.bIsDead = true;
                OnDeath();
            }
        }
    }
  
}
