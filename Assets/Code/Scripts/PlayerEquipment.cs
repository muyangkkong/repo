using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public GameObject lefthand;
    public GameObject righthand;
    public Instrument instrument;
    // public GameObject leftinst;
    // public GameObject rightinst;
    void Start() {
        if(instrument.leftArmed != null) GameObject.Instantiate(instrument.leftArmed).transform.SetParent(lefthand.transform, false);
        if(instrument.rightArmed != null) GameObject.Instantiate(instrument.rightArmed).transform.SetParent(righthand.transform, false);
    }

    void Update() {
        
    }
}
