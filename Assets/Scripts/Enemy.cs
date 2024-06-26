using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemyRb;
    public float speed;
    public int damage = 25;

    public int maxHealth = 100;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {   
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }


    void FixedUpdate()
    {
        enemyRb.velocity = Vector2.left * speed;
    }
}
