using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YBotHealth : Health
{
    public Animator animator;
    public static bool isDead = false;

    public GameObject yBot;


    public void Awake()
    {
        this.SetYBotHealth();
    }

    public void SetYBotHealth()
    {
        baseHealth = 20f;
        SetHealth();
    }




    public override void TakeDmg(float dmgAmount)
    {
        base.TakeDmg(dmgAmount);
        if (currentHealth <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;

            StartCoroutine(DeadAnimationDelay());

            isDead = true;

        }
        else
        {
            animator.SetTrigger("takeDmg");
        }
    }

    IEnumerator DeadAnimationDelay()
    {
        yield return new WaitForSeconds(3);
        Dead();
        GetComponent<Collider>().enabled = true;
    }

}
