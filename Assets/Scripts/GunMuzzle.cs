using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMuzzle : MonoBehaviour
{
    public GameObject gunMuzzle;
    public void HideMuzzle()
    {
        if (Input.GetMouseButton(0))
        {
            float CurrentTime = Time.time;
            ParticleSystem ps = GameObject.Find("WFX_MF 4P RIFLE2").GetComponent<ParticleSystem>();
            ps.Play();
        }
    }
}
