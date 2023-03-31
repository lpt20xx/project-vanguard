using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasingSpawner : PistolShoot
{
    [Header("Spawn Casing")]
    [SerializeField] private Transform casingExitTransform;

    [SerializeField] private float ejectPower = 150f;

    private void Awake()
    {
        poolTag = "Casing";
    }
    protected override void SpawnObject()
    {
        if (PlayerHealth.isDead)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            //Create the casing
            GameObject tempCasing;
            tempCasing = objectPooler.SpawnFromPool(poolTag, casingExitTransform.position, casingExitTransform.rotation) as GameObject;
            //Add force on casing to push it out
            tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitTransform.position - casingExitTransform.right * 0.3f - casingExitTransform.up * 0.6f), 1f);
            //Add torque to make casing spin in random direction
            tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);
            StartCoroutine(DisableCasing(tempCasing));
        }
    }

    IEnumerator DisableCasing(GameObject tempCasing)
    {
        yield return new WaitForSeconds(2f);
        //Destroy casing after X seconds
        tempCasing.SetActive(false);
    }
}
