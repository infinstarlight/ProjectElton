using DG.Tweening;
using UnityEngine;


public class TurretRotator : MonoBehaviour
{
    public Vector3 myVector;
    public Sequence rotateSequence;
    private GameObject GetTarget;
    public Sequence targetRotateSequence;

    private void Awake()
    {

        InitSequence();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitSequence();
        targetRotateSequence = DOTween.Sequence();
      
    }



    void InitSequence()
    {
          rotateSequence = DOTween.Sequence();
        rotateSequence.Append(transform.DORotate(myVector, 1, RotateMode.Fast));
        //rotateSequence.PrependInterval(1);
        rotateSequence.Play().SetLoops(-1, LoopType.Incremental);
    }

    void InitRotateSequence()
    {
        targetRotateSequence.Append(transform.DORotate(GetTarget.transform.position, 1, RotateMode.Fast));
        targetRotateSequence.Play();
    }

    public void RotateToTarget(GameObject Target)
    {
        GetTarget = Target;
        InitRotateSequence();
    }
}
