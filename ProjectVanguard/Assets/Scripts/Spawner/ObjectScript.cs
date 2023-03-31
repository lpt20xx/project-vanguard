using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour, IPooledObject
{
    protected float upForce = 1f;
    protected float sideForce = 0.1f;
    public virtual void OnObjectAddForce()
    {

        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);
        Vector3 force = new Vector3(xForce, yForce, zForce);

        GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }

}
