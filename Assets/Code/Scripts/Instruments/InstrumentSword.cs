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
        string[] ComboA = {"0A","3A","3A","3A","3A"};
        string[] ComboB = {"0A","3A","3A","4A","4A"};
        string[] ComboC = {"0A","3A","3B","3A","3B"};
        string[] ComboD = {"0A","2A","1B","2B","2A"};
        string[] ComboE = {"0A","2A","1B","2A","4B","4B"};

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
        return root.data;
/*         TimeCombo = Mathf.CeilToInt(playerAttacking.timer);

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
        } */
    }


    public override AttackData AttackB()
    {
        return root.data;
/*         TimeCombo = Mathf.CeilToInt(playerAttacking.timer);

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
        } */
    }

    public void ComboReset()
    {
/*         currentAttackProgress = root;
        AttackDelay = 1f;
        playerAttacking.timer = 0;
        playerAttacking.attacking = false; */
    }

}
