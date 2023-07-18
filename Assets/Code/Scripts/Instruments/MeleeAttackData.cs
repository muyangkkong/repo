using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Range {
    Vector2 pos1;
    Vector2 pos2;
}

public class MeleeAttackData : AttackData
{
    Range range;
    float duration;
}
