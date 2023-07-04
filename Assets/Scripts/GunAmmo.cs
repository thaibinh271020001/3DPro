using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunAmmo : MonoBehaviour
{
    public int magSize;
    public AudioSource[] reloadSounds;
    public UnityEvent loadAmmoChanged;

    private int _loadAmmoValue;
    public int loadedAmmo;
}
