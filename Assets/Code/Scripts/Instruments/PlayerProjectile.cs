using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("enemy")) {
            other.GetComponent<Enemy>().Damage(damage, 80f);
            Destroy(this.gameObject);
        }
    }
}
