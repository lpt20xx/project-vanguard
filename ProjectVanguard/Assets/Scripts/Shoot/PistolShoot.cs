using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShoot : Spawner
{
    [Header("Shoot and spawn bullet")]
    [SerializeField] protected Transform barrelTransform;
    public float dmg = 10f;
    public float range = 100f;
    //shoot limit
    public float fireRate = 15f;
    public float nextTimeToFire = 0f;

    public Camera fpsCam;

    private void Awake()
    {
        poolTag = "Bullet";
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
            this.Shoot();

            //spawn bullet
            GameObject bulletObj;
            bulletObj = objectPooler.SpawnFromPool(poolTag, barrelTransform.position, barrelTransform.rotation) as GameObject;
            //disable bullet after 3 seconds
            StartCoroutine(DisableBullet(bulletObj));

            if (AudioManager.Instance == null)
            {
                return;
            }
            else
            {
                AudioManager.Instance.PlaySFX("PistolFire");
            }

            

        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Health target = hit.transform.GetComponent<Health>();
            if(target != null )
            {
                target.TakeDmg(dmg);
            }
        }
    }

    IEnumerator DisableBullet(GameObject bulletObj)
    {
        yield return new WaitForSeconds(3f);
        //Destroy casing after X seconds
        bulletObj.SetActive(false);
    }


}
