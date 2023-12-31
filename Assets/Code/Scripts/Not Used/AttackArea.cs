using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    PlayerAttack playerAttacking;
    private void Awake() 
    {
        playerAttacking = GameObject.Find("Player").GetComponent<PlayerAttack>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("enemy dettected");
            float damage = /* playerAttacking.PlayerDamage */1;
            Health health = other.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}
