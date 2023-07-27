using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase/*  : MonoBehaviour */
{
    public AnimationClip animationClip;
    protected float damage;
    protected float delay;

    public AttackBase init() {
        damage = 1f;
        return this;
    }

    public AttackBase SetBaseData(AnimationClip animationClip, float damage, float delay) {
        this.animationClip = animationClip;
        this.damage = damage;
        this.delay = delay;
        return this;
    }

    public virtual AttackBase init(float x1, float y1, float x2, float y2) {
        return this;
    }
    public virtual IEnumerator Attack(Vector3 position, int direction, float power, float yieldGuage) {
        yield return null;
    }
}
