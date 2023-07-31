using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentSelect : MonoBehaviour
{
    public Instrument instrument;

    public void Holding()
    {
        Debug.Log("click");
        PlayerEquipment playerEquipment = GameObject.FindWithTag("Player").GetComponent<PlayerEquipment>();
        playerEquipment.instrument = instrument;
        playerEquipment.EquipInstrument();
        SelectDiliver.Instance.Select = instrument;
    }
}
