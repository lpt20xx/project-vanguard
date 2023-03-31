using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    public virtual void Awake()
    {

        if (instance == null)
        {
            instance = (T)(object)this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
