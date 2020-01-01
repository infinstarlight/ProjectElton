using UnityEngine;
using DG.Tweening;

public class AttractToPlayer : MonoBehaviour
{
    private Rigidbody GetRigidbody;
    private Item GetItem;
    // Start is called before the first frame update
    void Start()
    {
        GetRigidbody = GetComponent<Rigidbody>();
        GetItem = GetComponent<Item>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                // GetRigidbody.MovePosition(other.gameObject.transform.position * Time.fixedDeltaTime);
                transform.DOMove(other.gameObject.transform.position, 1.0f, false);
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
