using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemyCrescendo : MeleeEnemy
{
    float attackMultiplier;
    public float maxMutiplier;
    public float baseAttackDamage;
    public override IEnumerator Attack() {
        attackMultiplier += maxMutiplier / 5f;
        if(attackMultiplier > maxMutiplier + 1) attackMultiplier = maxMutiplier;
        AttackDamage = attackMultiplier * baseAttackDamage;
        yield return StartCoroutine(base.Attack());
    }
}
