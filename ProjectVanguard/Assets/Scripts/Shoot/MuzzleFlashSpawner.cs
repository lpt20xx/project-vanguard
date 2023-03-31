using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashSpawner : PistolShoot
{
    private void Awake()
    {
        poolTag = "MuzzleFlash";
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

            GameObject tempFlash;
            tempFlash = objectPooler.SpawnFromPool(poolTag, barrelTransform.position, barrelTransform.rotation);
            StartCoroutine(DisableMuzzleFlash(tempFlash));
        }
    }

    IEnumerator DisableMuzzleFlash(GameObject tempFlash)
    {
        yield return new WaitForSeconds(2f);
        //Destroy casing after X seconds
        tempFlash.SetActive(false);
    }
}
