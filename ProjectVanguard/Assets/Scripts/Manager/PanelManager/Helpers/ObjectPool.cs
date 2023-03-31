using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ObjectPool : PanelSingleton<ObjectPool>
{
    //list of the objects to be pooled
    public List<GameObject> prefabsForPool;



    //list of the pooled objects
    private List<GameObject> pooledObjects = new List<GameObject>();

    
    
    public GameObject GetObjectFromPool(string objectName)
    {
        //try to get a pooled instance
        var instance = pooledObjects.FirstOrDefault(obj => obj.name == objectName);

        // if we have a pooled instance already
        if(instance != null)
        {
            pooledObjects.Remove(instance);
            instance.SetActive(true);
            return instance;
        }

        //if we don't have a pooled instance
        var prefab = prefabsForPool.FirstOrDefault(obj => obj.name == objectName);
        if(prefab != null)
        {
            var newInstance = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
            newInstance.name = objectName;
            return newInstance;
        }

        Debug.LogWarning("Object pool doesn't have a prefab for the object with name " + objectName);
        return null;
    }

    public void PoolObject(GameObject obj)
    {
        obj.SetActive(false);
        pooledObjects.Add(obj);
    }

}
