using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Range {
    public Vector2 pos1;
    public Vector2 pos2;
}

public class MeleeAttack : AttackBase
{
    Range range;
    float delay;
    float damage;
    float angle;

    public override AttackBase init() {
        range.pos1 = new Vector2(0, 0);
        range.pos2 = new Vector2(5f, 1.8f);
        damage = 20f;
        return this;
    }
    public override void Attack(Vector3 position, int direction, float power) {
        Vector3 center = new Vector3((range.pos1.x + range.pos2.x)/2, (range.pos1.y + range.pos2.y)/2, 0.5f);
        Quaternion rotation = Quaternion.Euler(0, direction * 90 - 90, angle);
        center = rotation * center;
        Vector3 size = new Vector3(Mathf.Abs(range.pos1.x - range.pos2.x)/2, Mathf.Abs(range.pos1.y - range.pos2.y)/2, 0.5f);
        Collider[] hitColliders = Physics.OverlapBox(
            position + center,
            size,
            rotation,
            LayerMask.GetMask("enemy")
        );
        //temp code
        foreach(Collider collider in hitColliders) {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.Damage(1f * power, 120f);
        }
    }
}
