using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboData
{
    //Attack data (ex: damage, motion, ...)
    public int id;
    public string currentComboName;
    public int animationClipIdx;
    public AttackBase attack;
    public int[,] children = new int[5,2];
}

public class ComboDictionary
{
    Dictionary<int, ComboData> dictionary = new Dictionary<int, ComboData>();

    public ComboData GetComboData(int id) {
        return dictionary[id];
    }
    public void SetComboData(int id, ComboData attackData) {
        attackData.id = id;
        dictionary[id] = attackData;
    }
    public void SetComboData(int id, string currentComboName, int animationClipIdx, int[,] children) {
        ComboData attackData = new ComboData();
        attackData.id = id;
        attackData.currentComboName = currentComboName;
        attackData.animationClipIdx = animationClipIdx;
        attackData.children = children;
        dictionary[id] = attackData;
    }
}
