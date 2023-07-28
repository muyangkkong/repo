using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoSelect : MonoBehaviour
{
    
    PlayerEquipment equip;
    

    InstrumentPiano piano;
    void Start(){
        equip=GetComponent<PlayerEquipment>();
        piano=GetComponent<InstrumentPiano>();
        Holding();
    }
    

    // Start is called before the first frame update
    public void Holding()
    {
        
        Instantiate(piano.rightArmed).transform.SetParent(equip.righthand.transform, false);
        

    }

    // Update is called once per frame
    
}
