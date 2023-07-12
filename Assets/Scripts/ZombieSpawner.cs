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
    public Transform spawnPoint;

    private bool isRunning;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

    /*private void OnDrawGizmosSelected()
    {
        Handles.color = new Color(1, 0, 0, 0.1f);
        Handles.DrawSolidDisc(transform.position, Vector3.up, radius);
    }*/
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
        if (spawnQuantity > 0)
        {
            Instantiate(zombiePrefab, spawnPoint.position, transform.rotation);
            spawnQuantity--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player" && !isRunning)
        {
            isRunning = true;
            StartCoroutine(SpawnZombiesByTime());
            SpawnZombie();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Player" && isRunning)
        {
            isRunning = false;
            StopAllCoroutines();
        }
    }
}
