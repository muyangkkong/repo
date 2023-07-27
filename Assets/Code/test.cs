using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    NewBehaviourScript Base;
    
    Relic[] relicobjects;
    private GameObject m;
    // Start is called before the first frame update
    void Start()
    {
        
        Base=GameObject.Find("Canvas").transform.GetComponent<NewBehaviourScript>();
        foreach (Relic relic in relicobjects){
            Debug.Log(relic.RelicName);
        }
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag=="Player"){
            
            for (int i=0;i<Base.Text.Length;i++){
                
                     if (Base.Text[i].name==gameObject.name.Replace("(Clone)","")){
                            Base.Text[i].SetActive(true);
                            m=Base.Text[i];
                            m.transform.localPosition=new Vector3(gameObject.transform.position.x,gameObject.transform.position.y-50,0);
                                    
                                }
            }
        }
    }   
            
    void OnTriggerExit(Collider col){
              if (col.gameObject.tag=="Player"){
                   m.SetActive(false);
                             
                              }
                 
              }
         
    void OnTriggerStay(Collider col){
        if (col.gameObject.tag=="Player"){ 
            if (Input.GetKeyDown(KeyCode.C)){
                int j=RelicApply();
                Debug.Log(objectData.price);
               

                if (j!=-1){
                    if (Base.total_coin<objectData.price){
                        Debug.Log("돈없음");
                    }
                    else if (Base.total_coin>=objectData.price){
                        Base.total_coin-=objectData.price;
                        gameObject.SetActive(false);
                        m.SetActive(false);
                    }
                    
                    
                }
                
                //
            }
        }
    }
    
    int RelicApply(){
        
            if (gameObject.name==objectData.RelicName){
                return objectData.price;
            }
             return -1;
    }
}

