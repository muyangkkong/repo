using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Instrument : MonoBehaviour
{
    protected string InstrumentType;

    protected AttackTree root;
    protected AttackTree currentAttackProgress;

    public abstract void Construct();
    public abstract void Init();
    public abstract void AttackA();
    public abstract void AttackB();
}

public class AttackTree
{
    public AttackData data {get; set;}
    public AttackTree[,] Children {get; set;} = new AttackTree[5,2]; //[Timing][AttackType]
}

public class AttackData
{
    //Attack data (ex: damage, motion, ...)
    string currentComboName;
    float damage;
    string animationTrigger;
}