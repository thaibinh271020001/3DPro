using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfAmmo : MonoBehaviour
{
    public Text ammoText;
    public double ammo=30;
    public Animator anim;
    public AutomaticShooting automaticShooting;
    public ShootByButton ShootByButton;

    public void Update()
    {
#if UNITY_STANDALONE
        if (Input.GetMouseButton(0))
        {
            NumberAmmo();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            numberOfAmmo.Reloading();
        }
#endif

    }

    public void UpdateForButton()
    {
        NumberAmmo();
    }

    private void NumberAmmo()
    {
        if (ammo >= 0)
        {
            ammo = ammo - 0.05;
            ammoText.text = "" + (int)ammo;
        }
        else
        {
            NoMoreBullet();
            anim.SetBool("Shooting", false);
            anim.SetBool("Reloading", true);
        }
    }

    private void NoMoreBullet()
    {
        automaticShooting.enabled = false;
    }

    public void TimeToReload()
    {
        Invoke("Reloading", 3f);
    }

    public void Reloading()
    {
        ammoText.text = "30";
        anim.SetBool("Reloading", false);
        ammo = 30;
        automaticShooting.enabled = true;
        ShootByButton.enabled = true;
    }


}
