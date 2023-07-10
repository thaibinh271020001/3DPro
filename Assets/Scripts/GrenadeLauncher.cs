using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeLauncher : MonoBehaviour
{
    public Text BulletText;
    public GameObject TextReload;
    float numerOfBullet = 5;

    public AudioSource ShootSound;
    public AudioSource ReloadSound;

    public GameObject bulletReal;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;
    public GameObject bulletPrefab;

    void Update()
    {
        BulletText.text = "Bullet: " + numerOfBullet;

        if (numerOfBullet == 0)
        {
            TextReload.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                TextReload.SetActive(false);
                numerOfBullet = 5;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (bulletReal.activeInHierarchy == true)
            {
                if (numerOfBullet > 0)
                {
                    numerOfBullet--;
                }
            }

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.layer = 3;
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.right * bulletSpeed;
            Sound();
            bulletReal.SetActive(false);
            Invoke("ActiveBullet", 5f);
            PlayVFX();
        }        
    }

    public void ActiveBullet()
    {
        if (numerOfBullet > 0)
        {
            bulletReal.SetActive(true);
            ReloadSound.Play();
        }
    }

    public void Sound()
    {
        if(bulletReal.activeInHierarchy == true)
        {
            ShootSound.Play();
        }
    }

    public void PlayVFX()
    {
        ParticleSystem ps = GameObject.Find("RocketMuzzle").GetComponent<ParticleSystem>();
        ps.Play();
    }
}
