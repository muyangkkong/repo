using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : AttackBase
{
    float height = 0.9f;
    int projectileNum = 1;
    float speed = 8f;
    float duration = 2f;

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

    public override IEnumerator Attack(Vector3 position, int direction, float power, float yieldGuage) {
        yield return new WaitForSeconds(delay);
        int leftProjectileNum = projectileNum;
        while(leftProjectileNum > 0) {
            PlayerProjectile projectile = MonoBehaviour.Instantiate(projectileObject, position + Vector3.up * height, Quaternion.Euler(new Vector3(0,-direction * 90 + 180,0))).GetComponent<PlayerProjectile>();
            projectile.yieldGuage = yieldGuage;
            projectile.speed = speed;
            //duration set
            projectile.Shot(new Vector3(direction, 0, 0), power * damage);
            yield return new WaitForSeconds(0.05f);
            leftProjectileNum -= 1;
        }
    }
}