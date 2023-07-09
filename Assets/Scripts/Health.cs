using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHeathPoint;
    public UnityEvent onDie;
    public UnityEvent<int, int> onHealthChanged;
    public UnityEvent onTakeDamage;

    private int _healthPointValue;
    public int healthPoint
    {
        get => _healthPointValue;
        set
        {
            _healthPointValue = value;
            onHealthChanged.Invoke(_healthPointValue, maxHeathPoint);
        }
    }

    private bool IsDead => healthPoint <= 0;
    private void Start()
    {
        healthPoint = maxHeathPoint;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        healthPoint -= damage;
        onTakeDamage.Invoke();
        if (IsDead)
        {
            Die();
        }
    }

    private void Die()
    {
        onDie.Invoke();
    }
}
