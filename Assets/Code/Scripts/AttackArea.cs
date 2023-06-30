using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    PlayerAttacking playerAttacking;
    private void Awake() 
    {
        playerAttacking = GameObject.Find("Player").GetComponent<PlayerAttacking>();
    }
     private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {
            float damage = playerAttacking.PlayerDamage;
            //Health health = other.GetComponent<Health>();
            //health.Damage(damage);
        }
    }
}
