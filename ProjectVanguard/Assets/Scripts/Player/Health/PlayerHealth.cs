using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public Animator animator;
    public static bool isDead = false;

    public Slider healthBar;

    public GameObject levelControl;

    public void Awake()
    {
        this.SetPlayerHealth();
        this.SetMaxValueHealthBar();
    }

    public void Update()
    {
        this.SetValueHealthBar();
    }

    public void SetValueHealthBar()
    {
        healthBar.value = currentHealth;
    }

    public void SetMaxValueHealthBar()
    {
        healthBar.maxValue = baseHealth;
    }

    public void SetPlayerHealth()
    {
        baseHealth = 50f;
        SetHealth();
    }


    public override void TakeDmg(float dmgAmount)
    {
        base.TakeDmg(dmgAmount);
        if (currentHealth <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(DeadAnimationDelay());
            isDead = true;

            levelControl.GetComponent<GameOverScript>().enabled = true;
        }
        else
        {
            animator.SetTrigger("takeDmg");
        }
    }
    public override void Dead()
    {
        
    }

    IEnumerator DeadAnimationDelay()
    {
        yield return new WaitForSeconds(3);
        Dead();
    }
}
