using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTree
{
    public AttackData data {get; set;}
    public string Combo {get; set;}
    public AttackTree[,] Children {get; set;} = new AttackTree[5,2];

    public void InsertCombo(AttackTree current, string[] type, int ComNum) // 콤보 트리 생성
    {
        if (type.Length == ComNum) {return;}

        /*Parse Attack Data*/
        char[] AttackTypeChar = type[ComNum].ToCharArray();

        int TimingTemp = AttackTypeChar[0] - '0';
        int AttackTypeTemp = AttackTypeChar[1] - 'A';

        /*Insert Combo to AttackTree*/
        if (current.Children[TimingTemp,AttackTypeTemp] == null)
        {
            AttackTree TempAttackTree = new AttackTree();
            TempAttackTree.data = AttackDataCalcuate(AttackTypeTemp, TimingTemp);
            TempAttackTree.Combo = type[ComNum];
            current.Children[TimingTemp,AttackTypeTemp] = TempAttackTree;
        }

        /*Recursive Insert*/
        InsertCombo(current.Children[TimingTemp,AttackTypeTemp],type,ComNum+1);
    }

    public AttackData AttackDataCalcuate(int AttackType, int Timing) // AttackData 설정
    {
        float AttackDataDamageMulti = 1f;
        float TimingDamageMulti = 1f;
        float AttackDamage = 10f;

        /*damage hard codded*/
        switch(AttackType)
        {
            case 0:
                AttackDataDamageMulti = 1.0f;
                break;
            case 1:
                AttackDataDamageMulti = 1.5f;
                break;
        }

        switch (Timing)
        {
            case 0:
                TimingDamageMulti = 1.0f;
                break;
            case 1:
                TimingDamageMulti = 1.3f;
                break;
            case 2:
                TimingDamageMulti = 1.5f;
                break;
            case 3:
                TimingDamageMulti = 1.7f;
                break;
            case 4:
                TimingDamageMulti = 2f;
                break;
        }

        /*construct AttackData*/
        AttackData attackInfo = new AttackData();
        attackInfo.currentComboName = "Attack" + (char)(AttackType + 'A') + Timing.ToString(); 
        attackInfo.damage = AttackDamage * AttackDataDamageMulti * TimingDamageMulti ; 
        attackInfo.animationClipIdx = 1;
        
        return attackInfo;
    }
}