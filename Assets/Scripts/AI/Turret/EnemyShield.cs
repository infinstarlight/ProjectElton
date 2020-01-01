using DG.Tweening;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    private Sequence disableSequence;
    private Sequence enableSequence;
    public bool bDisableShield = false;
    // public Vector3 disableScaleVector;
    private float disableScaleFloat = 0.0f;
    private float enableScaleFloat = 5.0f;
    private TurretController GetController;
    // Start is called before the first frame update
    void Start()
    {
        disableSequence = DOTween.Sequence();
        enableSequence = DOTween.Sequence();
        InitDisableSequence();
        InitEnableSequence();
        disableSequence.Pause();
        enableSequence.Pause();
        GetController = GetComponentInParent<TurretController>();
    }


    public void ToggleShieldStatus(bool bEnable)
    {
        bDisableShield = bEnable;
        if (bDisableShield)
        {
            enableSequence.Pause();
            disableSequence.Play();

        }
        if (!bDisableShield)
        {
           disableSequence.Pause();
           enableSequence.Play();

        }
    }

    void InitDisableSequence()
    {
        disableSequence.Append(transform.DOScale(disableScaleFloat, 1));
    }
    void InitEnableSequence()
    {
        enableSequence.Append(transform.DOScale(enableScaleFloat, 1));
    }
}
