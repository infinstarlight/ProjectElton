using DG.Tweening;
using UnityEngine;


public class TurretRotator : MonoBehaviour
{
    public Vector3 myVector;
    private Sequence rotateSequence;

    private void Awake()
    {
       
        InitSequence();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitSequence();
    }



    void InitSequence()
    {
        rotateSequence = DOTween.Sequence();
        rotateSequence.Append(transform.DORotate(myVector, 1, RotateMode.Fast));
        //rotateSequence.PrependInterval(1);
        rotateSequence.Play().SetLoops(-1, LoopType.Incremental);
    }
}
