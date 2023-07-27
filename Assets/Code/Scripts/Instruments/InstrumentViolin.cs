using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentViolin : Instrument
{
    public override void Construct() {
        ParseCSV("Violin_Combo");
    }

    public override void Init()
    {
    }
}
