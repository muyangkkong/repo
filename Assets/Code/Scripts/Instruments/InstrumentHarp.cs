using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentHarp : Instrument
{
    public GameObject projectileU;

    public override void Construct() {
        ParseCSV("Harp_Combo");
    }

    public override void Init()
    {
        UltimateHarp ultimateHarp = new UltimateHarp();
        ultimateHarp.projectileObject = this.projectileU;
        this.ultimate = ultimateHarp;
    }
}
