using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image forceGround;

    public void OnHealthChanged(int currentHealth, int maxHealth)
    {
        forceGround.fillAmount = (float)currentHealth / maxHealth;
    }
}
