using DG.Tweening;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    private Sequence disableSequence;
    public bool bDisableShield = false;
    // public Vector3 disableScaleVector;
    public float disableScaleFloat = 0.0f;
    private TurretController GetController;
    // Start is called before the first frame update
    void Start()
    {
        disableSequence = DOTween.Sequence();
        InitSequence();
        disableSequence.Pause();
        GetController = GetComponentInParent<TurretController>();
    }


    public void ToggleShieldStatus(bool bEnable)
    {
        bDisableShield = bEnable;
        if (bDisableShield)
        {
            disableScaleFloat = 0.0f;
            disableSequence.Play();

        }
        if (!bDisableShield)
        {
            disableScaleFloat = 1.0f;
            disableSequence.Play();

        }
    }

    void InitSequence()
    {
        disableSequence.Append(transform.DOScale(disableScaleFloat, 1));
    }
}
