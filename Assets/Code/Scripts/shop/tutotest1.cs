using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutotest1 : MonoBehaviour
{
  
    
    public GameObject explain;
    
    // Start is called before the first frame update
    void Start()
    {
        
    
    }

    // Update is called once per frame
    void Update()
    {
        
     
    }
     void OnTriggerEnter(Collider col){
        if (col.gameObject.tag=="Player"){
              explain.SetActive(true);
            
            }
        }
    
            
    void OnTriggerExit(Collider col){
              if (col.gameObject.tag=="Player"){
                    explain.SetActive(false);
                             
                              }
                 
              }
    
         
    void OnTriggerStay(Collider col){
        if (col.gameObject.tag=="Player"){
                
            if (Input.GetKeyDown(KeyCode.C)){
               
                   
                        gameObject.SetActive(false);
                        explain.SetActive(false);
                    }
                    
                    
                }
                
                //
            }
    

    
}
         
    
    
/*     int RelicApply(){
        string Name=gameObject.name;
                if (objectData.RelicName==Name){
                    return objectData.price;

                }
                return -1;
    } */


