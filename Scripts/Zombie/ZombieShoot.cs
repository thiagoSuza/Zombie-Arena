using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate, fireCounter;

    private void Start()
    {
        fireRate = fireCounter;
    }
    void Update()
    {
        ZombieFire();
    }
    public void ZombieFire()
    {
        fireCounter -= Time.deltaTime;
        if (fireCounter <= 0)
        {
            fireCounter = fireRate;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            fireCounter = 3;
        }
    }

}
