using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : AttackBase
{
    Range range;
    float delay;
    float damage;
    float angle;

    public GameObject projectileObject;

    public override AttackBase init() {
        range.pos1 = new Vector2(0, 0);
        range.pos2 = new Vector2(5f, 1.8f);
        damage = 20f;
        return this;
    }

    public AttackBase init(GameObject projectileObject) {
        this.init();
        this.projectileObject = projectileObject;
        return this;
    }

    public override void Attack(Vector3 position, int direction, float power) {
        Projectile projectile = MonoBehaviour.Instantiate(projectileObject, position + Vector3.up, Quaternion.Euler(new Vector3(0,-direction * 90 + 180,0))).GetComponent<Projectile>();
        projectile.Shot(new Vector3(direction, 0, 0), power * 1f);
    }
}