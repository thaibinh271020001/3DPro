using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{

    public AudioSource ShootSound;

    public GameObject bulletReal;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;
    public GameObject bulletPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.right * bulletSpeed;
            bulletReal.SetActive(false);
            Sound();
            Invoke("ActiveBullet", 5f);
            PlayVFX();
        }        
    }

    public void ActiveBullet()
    {
        bulletReal.SetActive(true);
    }

    public void Sound()
    {
        ShootSound.Play();
    }

    public void PlayVFX()
    {
        ParticleSystem ps = GameObject.Find("RocketMuzzle").GetComponent<ParticleSystem>();
        ps.Play();
    }
}
