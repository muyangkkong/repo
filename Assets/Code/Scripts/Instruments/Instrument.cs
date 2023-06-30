using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Instrument : MonoBehaviour
{
    protected string InstrumentType;

    protected AttackTree root = new AttackTree();
    protected AttackTree currentAttackProgress = new AttackTree();

    public abstract void Construct();
    public abstract void Init();
    public abstract AttackData Attack(int timing, int type);

    public AttackTree GetCurrentAttackProgress() {
        return currentAttackProgress;
    }
    public void InitProgress() {
        currentAttackProgress = root;
    }
}

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
        attackInfo.animationTrigger = "AttackAnimationTrigger" + (char)(AttackType + 'A') +Timing.ToString();
        
        return attackInfo;
    }

    //? 무슨 코드인지 모름
    public AttackTree ComboTest(AttackTree current,int DataType, int Timing)
    {
        if (Timing >= 5) {return null;}
        if (current.Children[Timing, DataType] != null)
        {
            return current.Children[Timing, DataType];
        }
        else
        {
        return null;
        }
    }
}

public class AttackData
{
    //Attack data (ex: damage, motion, ...)
    public string currentComboName;
    public float damage;
    public string animationTrigger;

}

//시작 공격 : 모든 콤보를 시작하는 공격. 이전 공격이 없기 때문에 딜레이 역시 없어 A,B 두 가지 공격으로 정의됨
//연계 공격 : 이전의 공격으로부터 연계되는 공격. 1~4까지의 정수 딜레이와 A, B 두 가지 공격 총 8가지 공격으로 정의됨
//콤보 : 하나의 시작 공격과 0개 이상의 연계 공격의 조합을 의미함
//완성 콤보 : 콤보 중에서도 충분한 갯수의 연계 공격이 포함된 콤보로, 마지막 연계 공격 이후 딜레이 카운팅이 종료되는 콤보
//구현해야 할 것 : 몇가지 콤보를 공통으로 갖는 5개의 완성 콤보