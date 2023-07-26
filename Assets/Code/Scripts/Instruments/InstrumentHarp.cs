using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentHarp : Instrument
{
    Animator animator;

    public override void Construct()
    {
        int[,] children = new int[5,2];
        children[0,0] = 1001;
        attackDictionary.SetComboData(1000, "Initial State", -1, children);
        
        children = new int[5,2];
        children[2,0] = 1002;
        children[3,0] = 1003;
        attackDictionary.SetComboData(1001, "Combo Start", 0, children);

        children = new int[5,2];
        children[1,1] = 1004;
        attackDictionary.SetComboData(1002, "Short Combo", 0, children);

        children = new int[5,2];
        children[3,0] = 1005;
        children[3,1] = 1006;
        attackDictionary.SetComboData(1003, "Long Combo", 5, children);

        children = new int[5,2];
        children[2,0] = 1007;
        children[2,1] = 1008;
        attackDictionary.SetComboData(1004, "Jab", 6, children);

        children = new int[5,2];
        children[3,0] = 1009;
        children[4,0] = 1010;
        attackDictionary.SetComboData(1005, "Hook", 4, children);

        children = new int[5,2];
        children[3,0] = 1011;
        attackDictionary.SetComboData(1006, "Straight", 2, children);

        children = new int[5,2];
        children[4,1] = 1012;
        attackDictionary.SetComboData(1007, "Jab for Deep", 0, children);

        children = new int[5,2];
        children[2,0] = 1013;
        attackDictionary.SetComboData(1008, "Jab Jab", 0, children);

        children = new int[5,2];
        children[3,0] = 1014;
        attackDictionary.SetComboData(1009, "Hook Hook", 3, children);

        children = new int[5,2];
        children[4,0] = 1015;
        attackDictionary.SetComboData(1010, "Hook Straight", 2, children);

        children = new int[5,2];
        children[3,1] = 1016;
        attackDictionary.SetComboData(1011, "Straight Hook", 4, children);

        children = new int[5,2];
        children[4,1] = 1017;
        attackDictionary.SetComboData(1012, "Big Straight", 8, children);

        children = new int[5,2];
        attackDictionary.SetComboData(1013, "Jab Jab Jab", 0, children);
        attackDictionary.SetComboData(1014, "Hook Hook Hook", 7, children);
        attackDictionary.SetComboData(1015, "Hook Straight Straight", 7, children);
        attackDictionary.SetComboData(1016, "Straight Hook Hook", 7, children);
        attackDictionary.SetComboData(1017, "Big Straight Straight", 8, children);

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
    }
}
