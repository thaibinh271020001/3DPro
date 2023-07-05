using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject explosionPrefabs;
    public float explosionRadius;
    public float explosionForce;
    public int damage;

    private List<Health> oldVictims = new List<Health>();
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

    private void DeliverDamage(Collider victim)
    {
        Health health = victim.GetComponentInParent<Health>();

        if (health != null && !oldVictims.Contains(health))
        {
            health.TakeDamage(damage);
            oldVictims.Add(health);
        }
    }

    private void BlowObjects()
    {
        oldVictims.Clear();
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        for (int i = 0; i < affectedObjects.Length; i++)
        {
            DeliverDamage(affectedObjects[i]);
            Collider aff = affectedObjects[i];
            Rigidbody rigidbody = aff.attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
            }
        }
    }


}
