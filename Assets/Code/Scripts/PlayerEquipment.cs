using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public GameObject lefthand;
    public GameObject righthand;
    public Instrument instrument;
    
    void Start() {
        EquipInstrument();
    }

    void Update() {
        
    }

    void EquipInstrument() {
        if(instrument.leftArmed != null)
            Instantiate(instrument.leftArmed).transform.SetParent(lefthand.transform, false);
        if(instrument.rightArmed != null)
            Instantiate(instrument.rightArmed).transform.SetParent(righthand.transform, false);
    }
}
