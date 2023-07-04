using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycaster : MonoBehaviour
{
    public GameObject hitMakerPrefab;
    public Camera animingCamera;
    public LayerMask layerMask;
    public int damage;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            PerformRaycasting();
        }
    }
    private void PerformRaycasting()
    {
        Ray animingRay = new Ray(animingCamera.transform.position, animingCamera.transform.forward);
        if (Physics.Raycast(animingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMakerPrefab, hitInfo.point, effectRotation);
            DeliverDamge(hitInfo);
        }
    }

    private void DeliverDamge(RaycastHit hitInfo)
    {
        Health health = hitInfo.collider.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
