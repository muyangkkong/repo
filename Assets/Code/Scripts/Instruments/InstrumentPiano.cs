using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentPiano : Instrument
{
    Animator animator;
    /*
   PlayerAttack playerAttack;


    public int ComboNumber=0;


    private int TimeCombo=0;
    public float AttackDelay=0f;
    */

    public override void Construct()
    {
        int[,] children = new int[5, 2];
        children[0, 0] = 1001;
        attackDictionary.SetAttackData(1000, "Initial State", 10.0f, -1, children);

        children = new int[5, 2];
        children[2, 0] = 1002;
        children[3, 0] = 1003;
        attackDictionary.SetAttackData(1001, "Combo Start", 10.0f, 0, children);

        children = new int[5, 2];
        children[1, 1] = 1004;
        attackDictionary.SetAttackData(1002, "Short Combo", 10.0f, 0, children);

        children = new int[5, 2];
        children[3, 0] = 1005;
        children[3, 1] = 1006;
        attackDictionary.SetAttackData(1003, "Long Combo", 10.0f, 5, children);

        children = new int[5, 2];
        children[2, 0] = 1007;
        children[2, 1] = 1008;
        attackDictionary.SetAttackData(1004, "Jab", 10.0f, 6, children);

        children = new int[5, 2];
        children[3, 0] = 1009;
        children[4, 0] = 1010;
        attackDictionary.SetAttackData(1005, "Hook", 10.0f, 4, children);

        children = new int[5, 2];
        children[3, 0] = 1011;
        attackDictionary.SetAttackData(1006, "Straight", 10.0f, 2, children);

        children = new int[5, 2];
        children[4, 1] = 1012;
        attackDictionary.SetAttackData(1007, "Jab for Deep", 10.0f, 0, children);

        children = new int[5, 2];
        children[2, 0] = 1013;
        attackDictionary.SetAttackData(1008, "Jab Jab", 10.0f, 0, children);

        children = new int[5, 2];
        children[3, 0] = 1014;
        attackDictionary.SetAttackData(1009, "Hook Hook", 10.0f, 3, children);

        children = new int[5, 2];
        children[4, 0] = 1015;
        attackDictionary.SetAttackData(1010, "Hook Straight", 10.0f, 2, children);

        children = new int[5, 2];
        children[3, 1] = 1016;
        attackDictionary.SetAttackData(1011, "Straight Hook", 10.0f, 4, children);

        children = new int[5, 2];
        children[4, 1] = 1017;
        attackDictionary.SetAttackData(1012, "Big Straight", 10.0f, 8, children);

        children = new int[5, 2];
        attackDictionary.SetAttackData(1013, "Jab Jab Jab", 10.0f, 0, children);
        attackDictionary.SetAttackData(1014, "Hook Hook Hook", 10.0f, 7, children);
        attackDictionary.SetAttackData(1015, "Hook Straight Straight", 10.0f, 7, children);
        attackDictionary.SetAttackData(1016, "Straight Hook Hook", 10.0f, 7, children);
        attackDictionary.SetAttackData(1017, "Big Straight Straight", 10.0f, 8, children);
        /*         string[] ComboA = {"0A","3A","3A","3A","3A"};
                string[] ComboB = {"0A","3A","3A","4A","4A"};
                string[] ComboC = {"0A","3A","3B","3A","3B"};
                string[] ComboD = {"0A","2A","1B","2B","2A"};
                string[] ComboE = {"0A","2A","1B","2A","4B","4B"};

                root.InsertCombo(root, ComboA, 0);
                root.InsertCombo(root, ComboB, 0);
                root.InsertCombo(root, ComboC, 0);
                root.InsertCombo(root, ComboD, 0);
                root.InsertCombo(root, ComboE, 0); */
    }


    public override void Init()
    {
/*         currentAttackProgress = root;
        playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>(); */
    }

/*     public override ComboData Attack(int timing, int type) {
                // if(currentAttackProgress.Children[timing,type] == null) return null;

                // currentAttackProgress = currentAttackProgress.Children[timing,type];
                // return currentAttackProgress.data;
        if (GetCurrentAttackData().children[timing, type] == 0) return null;
        currentAttackId = GetCurrentAttackData().children[timing, type];
        return GetCurrentAttackData();
    } */

    
    public void ComboReset()
    {
/*         currentAttackProgress = root;
        AttackDelay = 1f;
        playerAttacking.timer = 0;
        playerAttacking.attacking = false; */
    }

}
