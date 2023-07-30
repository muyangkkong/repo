using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentPiano : Instrument
{
    public override void Construct() {
        ParseCSV("Piano_Combo");
    }

    public override void Init()
    {
        this.ultimate = new UltimatePiano();
    }
}
