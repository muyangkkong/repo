using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    public GameObject projectileObject;
    public override IEnumerator Attack() {
        yield return new WaitForSeconds(0.8f);
        animator.SetTrigger("Attack");
        currentState = State.attack;
        //attack animation start
        yield return new WaitForSeconds(0.4f);
        Projectile projectile = Instantiate(projectileObject, transform.position + Vector3.up * 0.5f, transform.rotation).GetComponent<Projectile>();
        projectile.Shot(new Vector3(direction, 0, 0), AttackDamage);
        yield return new WaitForSeconds(0.6f);
        //attack animation end
        StartCoroutine(base.Attack());
    }
}
