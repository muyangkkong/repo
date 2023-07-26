using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase/*  : MonoBehaviour */
{
    public AnimationClip animationClip;
    public virtual AttackBase init() {
        return this;
    }
    public virtual void Attack(Vector3 position, int direction, float power) {

    }
}
