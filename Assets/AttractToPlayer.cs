using UnityEngine;
using DG.Tweening;

public class AttractToPlayer : MonoBehaviour
{
    private Rigidbody GetRigidbody;
    private Item GetItem;
    private Sequence attractSequence;
    private GameObject playerGO;
    // Start is called before the first frame update
    void Start()
    {
        GetRigidbody = GetComponent<Rigidbody>();
        GetItem = GetComponent<Item>();
        playerGO = FindObjectOfType<Player>().gameObject;
        InitSequence();
    }

    void InitSequence()
    {
        attractSequence = DOTween.Sequence();
        transform.DOMove(playerGO.transform.position, 1.0f, false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                attractSequence.Play();
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                GetItem.ModifyMoney();
                Destroy(gameObject);

            }
        }
    }
}
