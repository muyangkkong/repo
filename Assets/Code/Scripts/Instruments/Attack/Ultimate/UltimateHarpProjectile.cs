using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateHarpProjectile : Projectile
{
    public float yieldGuage;
    public override void Shot(Vector3 direction, float damage) {
        this.direction = direction;
        this.damage = damage;
        isShot = true;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
        StartCoroutine(Guide());
    }

    IEnumerator Guide() {
        this.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(0.3f);
        while(true) {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 5f, LayerMask.GetMask("enemy"));
            if(colliders.Length > 0) {
                meshRenderer.material.color = Color.red;
                Vector3 target = colliders[0].transform.position;
                this.direction = (target - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
            }
            else {
                meshRenderer.material.color = this.color;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("enemy")) {
            other.GetComponent<Enemy>().Damage(damage, 80f);
            UltimateGuageManager.Instance.AddValue(yieldGuage);
            Destroy(this.gameObject);
        }
    }
}
