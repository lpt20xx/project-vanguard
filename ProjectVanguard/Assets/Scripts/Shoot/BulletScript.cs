using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : ObjectScript
{
    [SerializeField] private float bulletForce = 500f;
    [SerializeField] private Transform barrelTransform;

    private void Awake()
    {
        this.GetBarrelTransform();
    }
    public override void OnObjectAddForce()
    {
        Vector3 force = barrelTransform.forward * bulletForce;
        GetComponent<Rigidbody>().AddForce(force);
    }

    private void GetBarrelTransform()
    {
        barrelTransform = GameObject.FindGameObjectWithTag("Barrel").transform;
    }
}
