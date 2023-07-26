using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : AttackBase
{
    float height;
    int projectileNum;
    float speed;
    float duration;

    float angle;

    public GameObject projectileObject;

    public AttackBase init(GameObject projectileObject) {
        this.init();
        this.projectileObject = projectileObject;
        return this;
    }

    public override AttackBase init(float height, float projectileNum, float speed, float duration)
    {
        this.height = height;
        this.projectileNum = (int)(projectileNum + 0.5);
        this.speed = speed;
        this.duration = duration;
        return this;
    }

    public override IEnumerator Attack(Vector3 position, int direction, float power) {
        yield return new WaitForSeconds(delay);
        int leftProjectileNum = projectileNum;
        while(leftProjectileNum > 0) {
            Projectile projectile = MonoBehaviour.Instantiate(projectileObject, position + Vector3.up * height, Quaternion.Euler(new Vector3(0,-direction * 90 + 180,0))).GetComponent<Projectile>();
            projectile.speed = speed;
            //duration set
            projectile.Shot(new Vector3(direction, 0, 0), power * damage);
            yield return new WaitForSeconds(0.05f);
            leftProjectileNum -= 1;
        }
    }
}