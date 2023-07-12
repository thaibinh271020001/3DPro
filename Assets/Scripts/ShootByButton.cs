using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootByButton : MonoBehaviour
{
    public AutomaticShooting automaticShooting;
    public GunRaycaster gunRaycaster;
    public NumberOfAmmo numberOfAmmo;
    public GrenadeLauncher grenadeLauncher;

    private bool isPress = false;
    public bool isRifleGun = true;
    private void Update()
    {
        if (isRifleGun)
        {
            if (isPress)
            {
                PressToShootAutomaticGun();
            }
            else
            {
                automaticShooting.DisableAnimationShooting();
            }
        }
        else
        {
            if (isPress)
            {
                grenadeLauncher.ShootZocket();
            }
        }
    }
    
    private void PressToShootAutomaticGun()
    {
        if (numberOfAmmo.ammo > 0)
        {
            automaticShooting.UpdateFiring();
            gunRaycaster.PerformRaycasting();
            numberOfAmmo.UpdateForButton();
        }
    }

    public void PressToShoot(bool press)
    {
        isPress = press;
    }

    public void Reload()
    {
        if (isRifleGun)
        {
            numberOfAmmo.TimeToReload();
        }
        else
        {
            grenadeLauncher.TimeToReload();
        }
    }
}
