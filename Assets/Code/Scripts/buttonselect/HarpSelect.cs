using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpSelect : MonoBehaviour
{
    
    InstrumentHarp harp;
    PlayerEquipment equip;
    
    // Start is called before the first frame update
    void Start(){
        equip=GetComponent<PlayerEquipment>();
        harp=GetComponent<InstrumentHarp>();
        Holding();
    }
    public void Holding()
    {
        Instantiate(harp.leftArmed).transform.SetParent(equip.lefthand.transform, false);
    }

    // Update is called once per frame
   
}
