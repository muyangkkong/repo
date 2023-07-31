using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public GameObject lefthand;
    public GameObject righthand;
    public Instrument instrument;
    
    public GameObject leftArmed;
    public GameObject rightArmed;
    public GameObject thumbnail;

    void Start() {
        EquipInstrument();
    }

    void Update() {
    }

    public void EquipInstrument() {
        Destroy(leftArmed);
        Destroy(rightArmed);
        Destroy(thumbnail);

        if(instrument.leftArmed != null) {
            leftArmed = Instantiate(instrument.leftArmed);
            leftArmed.transform.SetParent(lefthand.transform, false);
        }
        if(instrument.rightArmed != null) {
            rightArmed = Instantiate(instrument.rightArmed);
            rightArmed.transform.SetParent(righthand.transform, false);
        }

        thumbnail = Instantiate(instrument.thumbnail);
        thumbnail.transform.SetParent(GameObject.Find("InstrumentInfo").transform, false);
    }
}
