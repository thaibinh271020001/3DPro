using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootByButton : MonoBehaviour
{
    public AutomaticShooting automaticShooting;
    public GunRaycaster gunRaycaster;

    private bool IsPress = false;
    private void Update()
    {
        if (IsPress == true)
        {
            automaticShooting.UpdateFiring();
            gunRaycaster.PerformRaycasting();
        }
    }

    public void PressToShoot(bool press)
    {
        IsPress = press;
    }
}
