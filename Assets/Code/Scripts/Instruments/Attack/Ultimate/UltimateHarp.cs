using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateHarp : Ultimate
{
    float height = 0.9f;
    int projectileNum = 1;
    float speed = 8f;
    float duration = 4f;

    int repeatNum = 8;
    float angle = 0;

    public GameObject projectileObject;

    bool penetration = true;

    public override IEnumerator Attack(Vector3 position, int direction, float power, float yieldGuage) {
        yield return new WaitForSeconds(0.2f);
        int leftProjectileNum = projectileNum;
        damage = 1.5f;
        angle = 0;
        for(int i = 0; i < repeatNum * 2; i++) {
            UltimateHarpProjectile projectile = MonoBehaviour.Instantiate(projectileObject, position + Vector3.up * height, Quaternion.Euler(new Vector3(0,-direction * 90 + 180, 0))).GetComponent<UltimateHarpProjectile>();
            projectile.yieldGuage = 0;
            projectile.speed = speed;
            projectile.duration = duration;
            projectile.Shot(Quaternion.Euler(new Vector3(0,0,angle*direction)) * new Vector3(direction, 0, 0), power * damage);

            /* projectile = MonoBehaviour.Instantiate(projectileObject, position + Vector3.up * height, Quaternion.Euler(new Vector3(0,-direction * 90 + 180, 0))).GetComponent<UltimateHarpProjectile>();
            projectile.yieldGuage = 0;
            projectile.speed = speed;
            projectile.duration = duration;
            projectile.Shot(Quaternion.Euler(new Vector3(0,0,-angle)) * new Vector3(direction, 0, 0), power * damage); */

            angle += (180f/repeatNum);
            yield return new WaitForSeconds(0.007f);
        }
    }
}
