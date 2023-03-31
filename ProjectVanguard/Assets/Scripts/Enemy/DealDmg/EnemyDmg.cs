using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDmg : MonoBehaviour
{
    public float dmgAmount = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDmg(dmgAmount);
        }
    }
}
