using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public GameObject lefthand;
    public GameObject righthand;
    public Instrument instrument;
    public GameObject leftinst;
    public GameObject rightinst;
    void Start() {
        GameObject.Instantiate(leftinst).transform.SetParent(lefthand.transform, false);
        GameObject.Instantiate(rightinst).transform.SetParent(righthand.transform, false);
    }

    void Update() {
        
    }
}
