using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            other.GetComponent<CharacterHP>().getDamage(damage);
            Destroy(this.gameObject);
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("Platform")) {
            Destroy(this.gameObject);
        }
    }
}
