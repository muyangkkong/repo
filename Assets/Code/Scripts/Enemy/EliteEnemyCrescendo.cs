using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemyCrescendo : MeleeEnemy
{
    float attackMultiplier = 1;
    public float maxMutiplier;
    public float baseAttackDamage;

    public override IEnumerator Attack() {
        attackMultiplier += maxMutiplier / 5f;
        if(attackMultiplier > maxMutiplier + 1) attackMultiplier = maxMutiplier + 1;
        this.transform.localScale = attackMultiplier * Vector3.one;
        AttackDamage = attackMultiplier * baseAttackDamage;
        yield return StartCoroutine(base.Attack());
    }
}
