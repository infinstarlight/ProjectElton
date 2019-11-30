using DG.Tweening;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    private Sequence disableSequence;
    public bool bEnableShield = false;
    // public Vector3 disableScaleVector;
    public float disableScaleFloat = 0.0f;
    // Start is called before the first frame update
    void Start()
    {


    }


    public void ToggleShieldStatus()
    {
     

        if (!bEnableShield)
        {
            InitSequence();
            disableSequence.Play();
        }
        if (bEnableShield)
        {
            disableSequence.Rewind(false);
        }
    }

    void InitSequence()
    {
        disableSequence = DOTween.Sequence();

        disableSequence.Append(transform.DOScale(disableScaleFloat, 1));


    }
}
