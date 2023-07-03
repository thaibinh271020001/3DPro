using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShooting : MonoBehaviour
{
    public int rpm;
    public AudioSource shootSound;
    public GameObject hitMakerPrefab;
    public Camera animingCamera;
    public LayerMask layerMask;
    public UnityEvent onShoot;

    private float lastShot;
    private float interval;

    private void Start() => interval = 60f / rpm; 

    private void Update()
    {
        if (Input.GetMouseButton(0)){
            UpdateFiring();
        }
    }

    private void UpdateFiring()
    {
        if (Time.time - lastShot >= interval)
        {
            Shoot();
            lastShot = Time.time;
        }
    }

    private void Shoot()
    {
        shootSound.Play();
        PerformRaycasting();
        onShoot.Invoke();
    }

   private void PerformRaycasting() 
    {
        Ray animingRay = new Ray(animingCamera.transform.position, animingCamera.transform.forward);
        if(Physics.Raycast(animingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMakerPrefab, hitInfo.point, effectRotation);
        }
    }
}
