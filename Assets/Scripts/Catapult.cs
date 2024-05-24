using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public Transform firePoint;
    public Transform castPoint;
    public GameObject ProjectileHayball;
    public Transform enemy;

    public float attackRange;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    bool Detected = false;

    Vector2 Direction;

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyPos = enemy.position;

        Direction = enemyPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, attackRange);

        if (rayInfo)
        {
            
            if(rayInfo.collider.gameObject.tag == "Enemy")
            {
                if (Detected ==  false)
                {
                    Detected = true;
                    
                }
            }

            else
            {
                if (Detected == true)
                {
                    Detected = false;
                    
                }
            }           
        }

        if (Detected)
        {
            if (Time.time >= nextAttackTime)
            {                             
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;               
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void Shoot()
    {
        Instantiate(ProjectileHayball, firePoint.position, firePoint.rotation);
    }
}
