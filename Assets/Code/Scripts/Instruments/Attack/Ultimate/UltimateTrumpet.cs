using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateTrumpet : Ultimate
{
    float height = 0.9f;
    int projectileNum = 1;
    float speed = 8f;
    float duration = 2f;

    int repeatNum = 30;
    float angle = 0;

    public GameObject projectileObject;

    bool penetration = true;

    public override IEnumerator Attack(Vector3 position, int direction, float power, float yieldGuage) {
        yield return new WaitForSeconds(0.5f);
        int leftProjectileNum = projectileNum;
        damage = 3f;
        angle = 0;
        for(int i = 0; i < repeatNum; i++) {
            PlayerProjectileP projectile = MonoBehaviour.Instantiate(projectileObject, position + Vector3.up * height, Quaternion.Euler(new Vector3(0,-direction * 90 + 180, angle))).GetComponent<PlayerProjectileP>();
            projectile.yieldGuage = 0;
            projectile.speed = speed;
            //duration set
            projectile.Shot(Quaternion.Euler(new Vector3(0,0,angle)) * new Vector3(direction, 0, 0), power * damage);

            angle += 12f;
        }
        yield return new WaitForSeconds(0.2f);
        angle = 6;
        for(int i = 0; i < repeatNum; i++) {
            PlayerProjectileP projectile = MonoBehaviour.Instantiate(projectileObject, position + Vector3.up * height, Quaternion.Euler(new Vector3(0,-direction * 90 + 180, angle))).GetComponent<PlayerProjectileP>();
            projectile.yieldGuage = 0;
            projectile.speed = speed;
            projectile.duration = duration;
            //duration set
            projectile.Shot(Quaternion.Euler(new Vector3(0,0,angle)) * new Vector3(direction, 0, 0), power * damage);

            angle += 12f;
        }
    }
}
