using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimatePiano: Ultimate
{
    Range range;
    float angle;
    int repeatNum = 20;

    public UltimatePiano() {
        range.pos1 = new Vector2(0f,0f);
        range.pos2 = new Vector2(3f,1.8f);
        damage = 20f;
    }

    public override IEnumerator Attack(Vector3 position, int direction, float power, float yieldGuage) {
        yield return new WaitForSeconds(0.4f);
        damage = 0.05f;
        range.pos2 = new Vector2(5f,1.8f);
        for(int i = 0; i < repeatNum; i++) {
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
            foreach(Collider collider in hitColliders) {
                Enemy enemy = collider.GetComponent<Enemy>();
                enemy.Damage(damage * power, -30f);
                UltimateGuageManager.Instance.AddValue(yieldGuage);
            }
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(0.5f);
        damage = 10f;
        range.pos2 = new Vector2(3f,1.8f);
        for(int i = 0; i < 2; i++) {
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
            foreach(Collider collider in hitColliders) {
                Enemy enemy = collider.GetComponent<Enemy>();
                enemy.Damage(damage * power, 120f);
                UltimateGuageManager.Instance.AddValue(yieldGuage);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
