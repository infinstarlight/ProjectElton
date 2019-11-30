using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class TurretRotator : MonoBehaviour
{
    public Vector3 myVector;
    private Sequence rotateSequence;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();

        InitSequence();
    }

 

    void InitSequence()
    {
        rotateSequence = DOTween.Sequence();
        rotateSequence.Append(transform.DORotate(myVector, 3, RotateMode.Fast));
        rotateSequence.PrependInterval(3);
        rotateSequence.Play().SetLoops(-1,LoopType.Incremental);
    }
}
