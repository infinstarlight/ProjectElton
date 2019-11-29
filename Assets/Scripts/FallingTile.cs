using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
    private Rigidbody GetRigidbody;
    public GameObject destroyGO;
    private void Awake()
    {
        GetRigidbody = GetComponent<Rigidbody>();
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                GetRigidbody.isKinematic = false;
                GetRigidbody.AddForce(Vector3.down * 50);
                StartCoroutine(DestroyTimer());
            }
        }
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(5.0f);
        Instantiate(destroyGO,transform.position,transform.rotation);
        Destroy(gameObject,0.5f);
    }
}
