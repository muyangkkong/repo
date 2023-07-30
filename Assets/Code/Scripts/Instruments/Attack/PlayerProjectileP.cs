using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileP : Projectile
{
    public float yieldGuage;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("enemy")) {
            other.GetComponent<Enemy>().Damage(damage, 80f);
            UltimateGuageManager.Instance.AddValue(yieldGuage);
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("Platform")) {
            //Destroy(this.gameObject);
        }
    }
}
