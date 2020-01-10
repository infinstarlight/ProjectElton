using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVolume : MonoBehaviour
{
    public float DamageAmount = 3.0f;
    public float DamageRate = 1.0f;
    private bool bStartDamageEvent = false;
    private GameObject hitObject;
    private float nextFire = 0.0f;

    private void Update()
    {
        if (bStartDamageEvent)
        {
            StartCoroutine(DamageOverTime());
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            hitObject = other.gameObject;
            if (hitObject.GetComponent<Player>())
            {
                bStartDamageEvent = true;
                StartCoroutine(DamageOverTime());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bStartDamageEvent = false;
        StopCoroutine(DamageOverTime());
    }

    IEnumerator DamageOverTime()
    {

        if (bStartDamageEvent)
        {

            DamageEvent();
            yield return DamageRate;
        }

    }

    void DamageEvent()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + DamageRate;
            if (bStartDamageEvent)
            {
                hitObject.GetComponent<Player>().damageEvent.Invoke(DamageAmount);
            }
        }
    }

}
