using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldScript : MonoBehaviour
{
    private ParticleSystem GetParticle;
    private ParticleSystemRenderer GetSystemRenderer;
    public float DamageToApply = 5.0f;
    public float DamageRate = 1.0f;

    private string shaderColorName = "Color_C8B672E6";
    private AudioSource source;
    private GameObject hitObject;

    private void Awake()
    {
        GetParticle = GetComponent<ParticleSystem>();
        GetSystemRenderer = GetParticle.GetComponent<ParticleSystemRenderer>();
        source = GetComponent<AudioSource>();
    }

  

    private void OnCollisionEnter(Collision other)
    {
        var em = GetParticle.emission;

        if (other.gameObject)
        {
            hitObject = other.gameObject;
            if (hitObject.GetComponent<Player>())
            {
                GetSystemRenderer.material.SetColor(shaderColorName, Color.red);
                em.SetBursts(
           new ParticleSystem.Burst[]{
                new ParticleSystem.Burst(0.1f, 250),
                new ParticleSystem.Burst(4.0f, 100)

           });
                 StartCoroutine(OnDamageEvent());
            }
        }
    }





    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                GetSystemRenderer.material.SetColor(shaderColorName, Color.green);
                StopCoroutine(OnDamageEvent());
                source.Stop();
            }
        }
    }

    IEnumerator OnDamageEvent()
    {
        yield return new WaitForSeconds(DamageRate);
        hitObject.SendMessage("PlayerDamageTaken", DamageToApply);
        source.PlayOneShot(source.clip);
    }
}
