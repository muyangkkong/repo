using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateViolin : Ultimate
{
    Range range;
    float angle;
    float interval = 0.2f;
    int repeatNum = 20;

    public GameObject violinObject;

    public UltimateViolin() {
        range.pos1 = new Vector2(-14f,-6f);
        range.pos2 = new Vector2(14f,10f);
        damage = 0.5f;
    }

    public override AttackBase init(float x1, float y1, float x2, float y2)
    {
        range.pos1.x = x1;
        range.pos1.y = y1;
        range.pos2.x = x2;
        range.pos2.y = y2;
        return this;
    }

    public override IEnumerator Attack(Vector3 position, int direction, float power, float yieldGuage) {
        yield return new WaitForSeconds(delay);
        GameObject player = GameObject.FindWithTag("Player");
        GameObject violin = MonoBehaviour.Instantiate(violinObject, position, Quaternion.Euler(Vector3.up * 90));
        violin.transform.localScale = Vector3.one * 8;
        //violin.transform.SetParent(player.transform);
        for(int i = 0; i < repeatNum; i++) {
            for(int j = 0; j < 10; j++) {
                position = player.transform.position;
                violin.transform.position = player.transform.position + Vector3.up * 4 + Vector3.back * 5;
                violin.transform.rotation = Quaternion.Euler(new Vector3(Mathf.Sin((i * 10 + j) * Mathf.PI / 27f) * 5f, 90, 0));
                yield return new WaitForSeconds(interval / 10f);
            }
            
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
                enemy.Damage(damage * power, 120f);
            }
            //yield return new WaitForSeconds(interval);
        }
        MonoBehaviour.Destroy(violin);
    }
}
