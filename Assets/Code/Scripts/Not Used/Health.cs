using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    private float MAX_HEALTH = 100f;

    public void Damage(float amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }
}