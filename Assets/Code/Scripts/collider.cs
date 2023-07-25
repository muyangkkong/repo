using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
    NewBehaviourScript Base;
    BoxCollider boxcollider;
    // Start is called before the first frame update
    void Start()
    {
        Base=GetComponent<NewBehaviourScript>();
        
    }
    // Update is called once per frame
    void Update()
    {
        Base.OnTriggerStay(boxcollider);
        Base.OnTriggerExit(boxcollider);
    }
    
   
}
