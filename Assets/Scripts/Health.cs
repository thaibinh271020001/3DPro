using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHeathPoint;
    public Animator anim;
    public UnityEvent onDie;

    public int healthPoint;

    private bool IsDead => healthPoint <= 0;
    private void Start()
    {
        healthPoint = maxHeathPoint;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        healthPoint -= damage;
        if (IsDead)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("Die");
        onDie.Invoke();
    }
}
