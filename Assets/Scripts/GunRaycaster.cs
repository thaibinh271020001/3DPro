using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycaster : MonoBehaviour
{
    public GameObject hitMakerPrefab;
    public GameObject hitMakerPrefabForZombie;
    public Camera animingCamera;
    public LayerMask layerMask;
    public LayerMask layerMaskZombie;
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
        if (Physics.Raycast(animingRay, out RaycastHit hitInfo, 1000f, layerMaskZombie))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMakerPrefabForZombie, hitInfo.point, effectRotation);
            DeliverDamge(hitInfo);
        }else if (Physics.Raycast(animingRay, out RaycastHit hit, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hit.normal);
            Instantiate(hitMakerPrefab, hit.point, effectRotation);
            DeliverDamge(hit);
        }
    }

    private void DeliverDamge(RaycastHit hitInfo)
    {
        Health health = hitInfo.collider.GetComponentInParent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
