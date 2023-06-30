using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentSword : Instrument
{
    Animator animator;
    PlayerAttacking playerAttacking;


    public int ComboNumber=0;


    private int TimeCombo=0;
    public float AttackDelay=0f;


    public override void Construct()
    {
        string[] ComboA = {"A0","A3","A3","A3","A3"};
        string[] ComboB = {"A0","A3","A3","A4","A4"};
        string[] ComboC = {"A0","A3","B3","A3","B3"};
        string[] ComboD = {"A0","A2","B1","B2","A2"};
        string[] ComboE = {"A0","A2","B1","A2","B4","B4"};

        root.InsertCombo(root, ComboA, 0);
        root.InsertCombo(root, ComboB, 0);
        root.InsertCombo(root, ComboC, 0);
        root.InsertCombo(root, ComboD, 0);
        root.InsertCombo(root, ComboE, 0);
    }


    public override void Init()
    {
        currentAttackProgress = root;
        playerAttacking = GameObject.Find("Player").GetComponent<PlayerAttacking>();
    }

    public override AttackData AttackA()
    { 
        TimeCombo = Mathf.CeilToInt(playerAttacking.timer);

        currentAttackProgress = currentAttackProgress.ComboTest(currentAttackProgress,0,TimeCombo);
        if (currentAttackProgress == null)
        {
            ComboReset();
            return null;
        }
        else
        {
            Debug.Log(currentAttackProgress.data.currentComboName);
            playerAttacking.timer = 0;
            return currentAttackProgress.data;
        }
    }


    public override AttackData AttackB()
    {
        TimeCombo = Mathf.CeilToInt(playerAttacking.timer);

        currentAttackProgress = currentAttackProgress.ComboTest(currentAttackProgress,1,TimeCombo);
        if (currentAttackProgress == null)
        {
            ComboReset();
            return null;
        }
        else
        {
            Debug.Log(currentAttackProgress.data.currentComboName);
            playerAttacking.timer = 0;
            return currentAttackProgress.data;
        }
    }

    public void ComboReset()
    {
        currentAttackProgress = root;
        AttackDelay = 1f;
        playerAttacking.timer = 0;
        playerAttacking.attacking = false;
    }

}
