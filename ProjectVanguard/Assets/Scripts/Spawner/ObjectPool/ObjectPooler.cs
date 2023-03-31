using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class ObjectPooler : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public List<Pool> pools;

    public static ObjectPooler Instance;


    private void Awake()
    {
        this.CheckInstance();
    }

    private void CheckInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        this.CreateNewPool();
    }

    private void CreateNewPool()
    {
        
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                //set parent
                obj.transform.SetParent(pool.parentTransform);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }

        
    }



    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }
        
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.SetPositionAndRotation(position, rotation);

        //object disable
        //StartCoroutine(ObjectDisable(objectToSpawn));

        //interface
        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObj != null)
        {
            pooledObj.OnObjectAddForce();
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;

       
    }

    IEnumerator ObjectDisable(GameObject objectToSpawn)
    {
        yield return new WaitForSeconds(10);
        objectToSpawn.SetActive(false);
    }
}
