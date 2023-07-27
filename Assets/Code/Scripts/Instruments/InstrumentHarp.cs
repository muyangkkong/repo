using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentHarp : Instrument
{
    public override void Construct() {
        ParseCSV("Harp_Combo");
    }

    public override void Init()
    {

    }
}
