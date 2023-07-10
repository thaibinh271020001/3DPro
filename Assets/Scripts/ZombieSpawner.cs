using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float radius;
    public int spawnQuantity;
    public float spawnInterval;
    float distance;


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = new Color(1, 0, 0, 0.1f);
        Handles.DrawSolidDisc(transform.position, Vector3.up, radius);
    }
#endif
    private void Start()
    {
        
    }

    private IEnumerator SpawnZombiesByTime()
    {
        while (spawnQuantity > 0)
        {
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnZombie()
    {
        if(spawnQuantity > 0)
        {
            Instantiate(zombiePrefab, transform.position, transform.rotation);
            spawnQuantity--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            SpawnZombie();
        }
    }
}
