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
    float angle;

    public override AttackBase init(float x1, float y1, float x2, float y2)
    {
        range.pos1.x = x1;
        range.pos1.y = y1;
        range.pos2.x = x2;
        range.pos2.y = y2;
        return this;
    }

    public override IEnumerator Attack(Vector3 position, int direction, float power) {
        yield return new WaitForSeconds(delay);
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
