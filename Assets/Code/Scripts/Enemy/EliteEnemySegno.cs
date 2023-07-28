using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemySegno : MeleeEnemy
{
    bool isSaved = false;

    List<GameObject> savedEnemy;
    List<GameObject> reviveList;

    public override void Damage(float amount, float knockback)
    {
        //if(!isSaved)
        setSegno();
        base.Damage(amount, knockback);
    }

    public void setSegno() {
        isSaved = true;
        //overlapsphere to save surround enemy object
        Collider[] colliders = Physics.OverlapSphere(transform.position, 9, LayerMask.GetMask("enemy"));
        savedEnemy = new List<GameObject>();
        reviveList = new List<GameObject>();
        foreach(Collider collider in colliders) {
            if(collider.gameObject == this.gameObject) continue;
            savedEnemy.Add(collider.gameObject);
            GameObject temp = Instantiate(collider.gameObject, collider.transform.position, collider.transform.rotation);
            temp.SetActive(false);
            reviveList.Add(temp);
        }
    }

    public override void Die() {
        foreach(GameObject enemy in savedEnemy) {
            Destroy(enemy);
        }
        foreach(GameObject enemy in reviveList) {
            enemy.SetActive(true);
        }
        currentHp = maxHp;
        
        base.Die();
    }
}
