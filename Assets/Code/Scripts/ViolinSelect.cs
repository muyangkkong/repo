using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolinSelect : MonoBehaviour
{
    PlayerEquipment equip;
    InstrumentViolin violin;
    // Start is called before the first frame update
    void Start(){
       
        violin=GetComponent<InstrumentViolin>();
        Holding();
    }
    public void Holding()
    {
       Instantiate(violin.rightArmed).transform.SetParent(equip.righthand.transform, false);
       Instantiate(violin.leftArmed).transform.SetParent(equip.lefthand.transform, false);
    } 

    // Update is called once per frame
    
}
