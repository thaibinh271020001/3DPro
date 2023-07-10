using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Animator anim;
    public int damage;
    public Health playerHealth;
    int count = 0;

    private void Start()
    {
        playerHealth = Player.Instance.health;
    }

    public void StartAttack()
    {
        anim.SetBool("IsAttacking", true);
    }
    public void StopAttack() => anim.SetBool("IsAttacking", false);

    public void OnAttack()
    {

        playerHealth.TakeDamage(damage);
        
        if(count % 2 != 0)
        {
            Player.Instance.playerUI.ShowRightScratch();
        }
        else
        {
            Player.Instance.playerUI.ShowLeftScratch();
        }
        count++;
    }
}
