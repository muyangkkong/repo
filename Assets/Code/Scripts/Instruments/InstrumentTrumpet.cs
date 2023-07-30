using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentTrumpet : Instrument
{
    public override void Construct() {
        ParseCSV("Trumpet_Combo");
    }

    public override void Init()
    {
        UltimateTrumpet ultimateTrumpet = new UltimateTrumpet();
        ultimateTrumpet.projectileObject = this.projectileP;
        this.ultimate = ultimateTrumpet;
    }
}
