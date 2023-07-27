using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemySegno : Enemy
{
    bool isDamaged = false;

    public override void Damage(float amount, float knockback)
    {
        base.Damage(amount, knockback);
    }

    public void setSegno() {
        isDamaged = true;
        //overlapsphere to save surround enemy object
        Collider colliders[];
    }
}
