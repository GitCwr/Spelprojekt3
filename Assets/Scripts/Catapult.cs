using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public Transform firePoint;
    public GameObject ProjectileHayball;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Shoot()
    {
        Instantiate(ProjectileHayball, firePoint.position, firePoint.rotation);
    }
}
