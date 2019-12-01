using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShield : MonoBehaviour, IDamageable<float>
{
    public float CurrentHealth = 0.0f;
    public float MaxHealth = 5.0f;
    public float ShieldRenableDelay = 30.0f;

    private TurretController GetTurret;
    public bool bIsDisabled = false;
    private Material startMaterial;
    public Material hitMaterial;
    private MeshRenderer myRenderer;
    public GameObject[] itemsGO = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {

        CurrentHealth = MaxHealth;
        GetTurret = FindObjectOfType<TurretController>();
        myRenderer = GetComponentInChildren<MeshRenderer>();
        startMaterial = myRenderer.material;
        itemsGO[0] = null;
        itemsGO[1] = null;
        itemsGO[2] = null;
        var smallhealthGO = Resources.Load<GameObject>("Prefabs/Items/SmallHealthPickup") as GameObject;
        var medHealthGo = Resources.Load<GameObject>("Prefabs/Items/MedHealthPickup") as GameObject;
        var smallammoGO = Resources.Load<GameObject>("Prefabs/Items/SmallAmmoPickup") as GameObject;

        itemsGO[0] = smallhealthGO;
        itemsGO[1] = smallammoGO;
        itemsGO[2] = medHealthGo;
    }

   

    public void OnDamageApplied(float damageTaken)
    {
        CurrentHealth -= damageTaken;
        if (CurrentHealth <= 0)
        {

            bIsDisabled = true;
            StartCoroutine(RegenHealth());
            myRenderer.material = hitMaterial;
            SpawnRandomPickup();
            GetTurret.CheckShield(this);
        }
    }

    public void SpawnRandomPickup()
    {
        Instantiate(itemsGO[Random.Range(0, itemsGO.Length)], transform.position, transform.rotation);
    }

    IEnumerator RegenHealth()
    {
        yield return new WaitForSeconds(ShieldRenableDelay);
        if (bIsDisabled)
        {
            ++CurrentHealth;
            if (CurrentHealth >= MaxHealth)
            {
                bIsDisabled = false;
                GetTurret.CheckShield(this);
                myRenderer.material = startMaterial;
                StopCoroutine(RegenHealth());

            }
        }

    }
}
