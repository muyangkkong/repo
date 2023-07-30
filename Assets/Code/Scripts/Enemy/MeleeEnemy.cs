using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public override IEnumerator Attack() {
        animator.SetTrigger("Attack");
        currentState = State.attack;
        //attack animation start
        yield return new WaitForSeconds(0.6f);
        Vector3 center = transform.position + Vector3.right * direction * chaseRangeMin * 0.5f + Vector3.up * 0.5f;
        Quaternion rotation = Quaternion.Euler(0, /* direction * 90 - 90 */0, 0);
        center = rotation * center;
        Vector3 size = new Vector3(chaseRangeMin * 0.5f, 0.5f, 0.5f);
        Collider[] hitColliders = Physics.OverlapBox(
            center,
            size,
            rotation,
            LayerMask.GetMask("Player")
        );

        foreach(Collider collider in hitColliders) {
            if(collider.isTrigger) continue;
            CharacterHP hp = collider.GetComponent<CharacterHP>();
            hp.getDamage(AttackDamage);
        }
        yield return new WaitForSeconds(0.4f);
        //attack animation end
        StartCoroutine(base.Attack());
    }
}
