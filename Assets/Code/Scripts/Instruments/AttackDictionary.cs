using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackData
{
    //Attack data (ex: damage, motion, ...)
    public int id;
    public string currentComboName;
    public float damage;
    public int animationClipIdx;
    public int[,] children = new int[5,2];
}

public class AttackDictionary
{
    Dictionary<int, AttackData> dictionary = new Dictionary<int, AttackData>();

    public AttackData GetAttackData(int id) {
        return dictionary[id];
    }
    public void SetAttackData(int id, AttackData attackData) {
        attackData.id = id;
        dictionary[id] = attackData;
    }
    public void SetAttackData(int id, string currentComboName, float damage, int animationClipIdx, int[,] children) {
        AttackData attackData = new AttackData();
        attackData.id = id;
        attackData.currentComboName = currentComboName;
        attackData.damage = damage;
        attackData.animationClipIdx = animationClipIdx;
        attackData.children = children;
        dictionary[id] = attackData;
    }
}
