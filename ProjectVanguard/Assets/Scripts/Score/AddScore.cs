using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public Scoring score;

    public GameObject yBot;
    public void Update()
    {
        this.IncreaseScore();
        
    }

    public void IncreaseScore()
    {
        if (YBotHealth.isDead)
        {
            score.AddScore(1);
            YBotHealth.isDead = false;
            StartCoroutine(RespawnEnemyDelay());
        }
        
    }

    IEnumerator RespawnEnemyDelay()
    {
        yield return new WaitForSeconds(4f);
        
        Vector3 randomPos = new Vector3(Random.Range(715, 730), 20, Random.Range(210, 225));
        yBot.transform.position = randomPos;
        yBot.SetActive(true);
    }
}
