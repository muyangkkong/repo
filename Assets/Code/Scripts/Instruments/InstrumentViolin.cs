using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class InstrumentViolin : Instrument
{
    Animator animator;

    public override void Construct()
    {
        int[,] children;

        List<Dictionary<string,object>> ViolinCombo = CSVReader.Read("Violin_Combo");
        for (int i=0; i < ViolinCombo.Count; i++)
        {
            children = new int[5,2];
            if ((int)ViolinCombo[i]["0A"]!=0) { children[0,0] = (int)ViolinCombo[i]["0A"]; } 
            if ((int)ViolinCombo[i]["1A"]!=0) { children[1,0] = (int)ViolinCombo[i]["1A"]; } 
            if ((int)ViolinCombo[i]["2A"]!=0) { children[2,0] = (int)ViolinCombo[i]["2A"]; } 
            if ((int)ViolinCombo[i]["3A"]!=0) { children[3,0] = (int)ViolinCombo[i]["3A"]; }
            if ((int)ViolinCombo[i]["4A"]!=0) { children[4,0] = (int)ViolinCombo[i]["4A"]; } 

            if ((int)ViolinCombo[i]["0B"]!=0) { children[0,1] = (int)ViolinCombo[i]["0B"]; } 
            if ((int)ViolinCombo[i]["1B"]!=0) { children[1,1] = (int)ViolinCombo[i]["1B"]; } 
            if ((int)ViolinCombo[i]["2B"]!=0) { children[2,1] = (int)ViolinCombo[i]["2B"]; }
            if ((int)ViolinCombo[i]["3B"]!=0) { children[3,1] = (int)ViolinCombo[i]["3B"]; }
            if ((int)ViolinCombo[i]["4B"]!=0) { children[3,1] = (int)ViolinCombo[i]["4B"]; }             

            comboDictionary.SetComboData((int)ViolinCombo[i]["ID"],(string)ViolinCombo[i]["Name"], 0 , children);
        }

        /*
        int[,] children = new int[5,2];
        children[0,0] = 1001;
        attackDictionary.SetAttackData(1000, "Initial State", 10.0f, -1, children);
        
        children = new int[5,2];
        children[2,0] = 1002;
        children[3,0] = 1003;
        attackDictionary.SetAttackData(1001, "Combo Start", 10.0f, 0, children);

        children = new int[5,2];
        children[1,1] = 1004;
        attackDictionary.SetAttackData(1002, "Short Combo", 10.0f, 0, children);

        children = new int[5,2];
        children[3,0] = 1005;
        children[3,1] = 1006;
        attackDictionary.SetAttackData(1003, "Long Combo", 10.0f, 5, children);

        children = new int[5,2];
        children[2,0] = 1007;
        children[2,1] = 1008;
        attackDictionary.SetAttackData(1004, "Jab", 10.0f, 6, children);

        children = new int[5,2];
        children[3,0] = 1009;
        children[4,0] = 1010;
        attackDictionary.SetAttackData(1005, "Hook", 10.0f, 4, children);

        children = new int[5,2];
        children[3,0] = 1011;
        attackDictionary.SetAttackData(1006, "Straight", 10.0f, 2, children);

        children = new int[5,2];
        children[4,1] = 1012;
        attackDictionary.SetAttackData(1007, "Jab for Deep", 10.0f, 0, children);

        children = new int[5,2];
        children[2,0] = 1013;
        attackDictionary.SetAttackData(1008, "Jab Jab", 10.0f, 0, children);

        children = new int[5,2];
        children[3,0] = 1014;
        attackDictionary.SetAttackData(1009, "Hook Hook", 10.0f, 3, children);

        children = new int[5,2];
        children[4,0] = 1015;
        attackDictionary.SetAttackData(1010, "Hook Straight", 10.0f, 2, children);

        children = new int[5,2];
        children[3,1] = 1016;
        attackDictionary.SetAttackData(1011, "Straight Hook", 10.0f, 4, children);

        children = new int[5,2];
        children[4,1] = 1017;
        attackDictionary.SetAttackData(1012, "Big Straight", 10.0f, 8, children);

        children = new int[5,2];
        attackDictionary.SetAttackData(1013, "Jab Jab Jab", 10.0f, 0, children);
        attackDictionary.SetAttackData(1014, "Hook Hook Hook", 10.0f, 7, children);
        attackDictionary.SetAttackData(1015, "Hook Straight Straight", 10.0f, 7, children);
        attackDictionary.SetAttackData(1016, "Straight Hook Hook", 10.0f, 7, children);
        attackDictionary.SetAttackData(1017, "Big Straight Straight", 10.0f, 8, children);
        */    
    }

    public override void InitProgress() {
        currentAttackId = 1000;
    }

    public override void Init()
    {
    }
}
