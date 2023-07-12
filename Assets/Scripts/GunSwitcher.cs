using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    public GameObject[] guns;
    public ShootByButton shootByButton;

    private int currentIndex;
#if UNITY_STANDALONE
    private void Update()
    {
        for(int i=0; i<guns.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) || Input.GetKeyDown(KeyCode.Keypad1 + i)){
                SetActiveGun(i);
            }
        }
    }
#endif

    public void SwitchGun()
    {
        currentIndex = (currentIndex + 1) % guns.Length;
        SetActiveGun(currentIndex);
        if (shootByButton.isRifleGun)
        {
            shootByButton.isRifleGun = false;
        }
        else
        {
            shootByButton.isRifleGun = true;
        }
        
    }
    public void SetActiveGun(int gunIndex)
    {
        for(int i =0; i < guns.Length; i++)
        {
            bool isActive = (i != gunIndex);
            guns[i].SetActive(isActive);

            if (isActive)
            {
                guns[i].SendMessage("OnGunSelected", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
