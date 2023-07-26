using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentTrumpet : Instrument
{
    public override void Construct() {
        int[,] children = new int[5,2];
        children[0,0] = 1001;
        children[0,1] = 1101;
        attackDictionary.SetAttackData(1000, "Initial State", 0f, -1, children);


        List<Dictionary<string,object>> TrumpetCombo = CSVReader.Read("Trumpet_Combo");
        for (int i=0; i < TrumpetCombo.Count; i++)
        {
            children = new int[5,2];
            if ((int)TrumpetCombo[i]["1A"]!=0) { children[1,0] = (int)TrumpetCombo[i]["1A"]; } 
            if ((int)TrumpetCombo[i]["2A"]!=0) { children[2,0] = (int)TrumpetCombo[i]["2A"]; } 
            if ((int)TrumpetCombo[i]["3A"]!=0) { children[3,0] = (int)TrumpetCombo[i]["3A"]; }
            if ((int)TrumpetCombo[i]["4A"]!=0) { children[4,0] = (int)TrumpetCombo[i]["4A"]; } 

            if ((int)TrumpetCombo[i]["1B"]!=0) { children[1,1] = (int)TrumpetCombo[i]["1B"]; } 
            if ((int)TrumpetCombo[i]["2B"]!=0) { children[2,1] = (int)TrumpetCombo[i]["2B"]; }
            if ((int)TrumpetCombo[i]["3B"]!=0) { children[3,1] = (int)TrumpetCombo[i]["3B"]; }
            if ((int)TrumpetCombo[i]["4B"]!=0) { children[3,1] = (int)TrumpetCombo[i]["4B"]; }             

            attackDictionary.SetAttackData((int)TrumpetCombo[i]["ID"],(string)TrumpetCombo[i]["Name"],10.0f, 0 , children);
        }
    }



    // Start is called before the first frame update
    public override void Init()
    {
        
    }
}
