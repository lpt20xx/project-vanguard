using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float baseHealth;
    public float currentHealth;
    

    public void SetHealth()
    {
        currentHealth = baseHealth;
    }
    public virtual void TakeDmg(float dmgAmount)
    {
        currentHealth -= dmgAmount;
    }
    public virtual void Dead()
    {
        gameObject.SetActive(false);
        //reset health
        currentHealth = baseHealth;
    }
}
