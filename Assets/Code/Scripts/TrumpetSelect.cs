using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpetSelect : MonoBehaviour
{
    PlayerEquipment equip;
    

    InstrumentViolin trumpet;
    // Start is called before the first frame update
    void Start()
    {
        equip=GetComponent<PlayerEquipment>();
        trumpet=GetComponent<InstrumentViolin>();
        Holding();
        
    }

    // Update is called once per frame
    void Holding()
    {
        Instantiate(trumpet.rightArmed).transform.SetParent(equip.righthand.transform, false);
    }
}
