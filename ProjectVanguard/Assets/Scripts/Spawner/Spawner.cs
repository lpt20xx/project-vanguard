using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    protected ObjectPooler objectPooler;
    protected string poolTag;

    private void Start()
    {
        this.ObjectPoolerInstance();
    }

    private void ObjectPoolerInstance()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate()
    {
        this.SpawnObject();
    }

    protected virtual void SpawnObject()
    {
        objectPooler.SpawnFromPool(poolTag, transform.position, Quaternion.identity);
    }

}
