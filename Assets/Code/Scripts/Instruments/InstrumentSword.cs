using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentSword : Instrument
{
    Animator animator;
    PlayerAttack playerAttack;


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
        playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
    }

    public override AttackData Attack(int timing, int type) {
        if(currentAttackProgress.Children[timing,type] == null) return null;
        
        currentAttackProgress = currentAttackProgress.Children[timing,type];
        return currentAttackProgress.data;
    }


    public void ComboReset()
    {
/*         currentAttackProgress = root;
        AttackDelay = 1f;
        playerAttacking.timer = 0;
        playerAttacking.attacking = false; */
    }

}
