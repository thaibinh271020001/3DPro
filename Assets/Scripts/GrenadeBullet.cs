using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject explosionPrefabs;
    public float explosionRadius;
    public float explosionForce;
    private void Start()
    {
        Debug.Log(gameObject.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefabs, transform.position, transform.rotation);
        Destroy(gameObject);
        BlowObjects();
    }

    private void BlowObjects()
    {
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(var aff in affectedObjects)
        {
            Rigidbody rigidbody = aff.attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
            }
        }
    }
}
