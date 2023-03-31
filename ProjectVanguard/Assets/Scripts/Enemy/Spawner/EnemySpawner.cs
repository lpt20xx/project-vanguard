using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : Spawner
{
    [SerializeField] protected Transform enemySpawner;
    private void Awake()
    {
        poolTag = "YBot";
    }
    protected override void SpawnObject()
    {
        if(Input.GetKeyDown(KeyCode.R)) 
        {
            Vector3 randomPosition = new Vector3(Random.Range(715, 730), enemySpawner.position.y, Random.Range(210, 230));
            GameObject enemy;
            enemy = objectPooler.SpawnFromPool(poolTag, randomPosition, enemySpawner.rotation);
            randomPosition += Vector3.forward;
        }
    }

}
