using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    public bool isStun;
    private float TimeStun = 2f;

    void Start() => currentHealth = maxHealth;

    private void Update()
    {
        if (isStun && TimeStun > 0)
        {
            TimeStun -= Time.deltaTime;
            if (TimeStun <= 0f)
            {
                isStun = false;
                TimeStun = 2f;
            }
            return;
        }
    }
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0) Destroy(gameObject);
    }
}
