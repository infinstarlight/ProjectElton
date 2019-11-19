using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChargeObject : MonoBehaviour, IChargeable
{
    public Light myLight;
    public GameObject boundGO;
    public float ChargeLimit = 3.0f;
    public float ChargeMod = 0.15f;
    public float CurrentChargeAmount = 0.0f;
    public float ChargeDecRate = 1f;
    public float ChargeDecAmount = 0.01f;
    public float WrongAmmoTypeMod = 3.0f;
    private float ChargePercentage = 0.0f;
    public EAmmoType desiredAmmoType;
    private bool bIsCharged = false;

    private MeshRenderer myRenderer;
    private Material myMaterial;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myMaterial = myRenderer.material;

    }

    // Update is called once per frame
    void Update()
    {
        ChargePercentage = CurrentChargeAmount / ChargeLimit;
        if (ChargePercentage > 0)
        {
            StartCoroutine(DecreaseChargeOverTime());
        }
        if (CurrentChargeAmount >= ChargeLimit)
        {
            StopCoroutine(DecreaseChargeOverTime());
            ChargeDecRate = 0;
        }
        //myMaterial.SetFloat("AnimationSpeed", ChargePercentage);

    }

    public void ModCharge(float ModAmount, EAmmoType hitAmmoType)
    {
        ChargeMod = ModAmount;
        CurrentChargeAmount += ChargeMod;
        if (CurrentChargeAmount >= ChargeLimit)
        {
            Debug.Log("Limit has been reached!");
            bIsCharged = true;
            StopCoroutine(DecreaseChargeOverTime());
            boundGO.SendMessage("OnChargerEvent");
        }
        if (CurrentChargeAmount <= 0)
        {
            StopCoroutine(DecreaseChargeOverTime());
        }

        if (hitAmmoType != desiredAmmoType)
        {
            StopCoroutine(DecreaseChargeOverTime());
            //CurrentChargeAmount = CurrentChargeAmount - WrongAmmoTypeMod;
        }
    }

    public void OnChargeEvent()
    {

    }

    public IEnumerator DecreaseChargeOverTime()
    {
        if (!bIsCharged)
        {
            CurrentChargeAmount -= ChargeDecAmount;
            yield return ChargeDecRate;
        }

    }
}
