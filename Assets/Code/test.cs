using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    NewBehaviourScript Base;
    
    Relic objectData;
    private GameObject M;//전역변수로 어떻게 하지..?
    // Start is called before the first frame update
    void Start()
    {
        
        Base=GameObject.Find("Canvas").transform.GetComponent<NewBehaviourScript>();
        objectData = ScriptableObject.CreateInstance<Relic>();
        M=GetComponent<GameObject>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag=="Player"){
            
            foreach (GameObject m in Base.Text){
                             if (m.name==gameObject.name){
                                    M=Instantiate(m);
                                    Debug.Log(M.name);
                                }
            }
        }
    }   
            
    void OnTriggerExit(Collider col){
              if (col.gameObject.tag=="Player"){
                M.SetActive(false);
                             
                              }
                 
              }
         
    void OnTriggerStay(Collider col){
        if (col.gameObject.tag=="Player"){
                           
                           
                           M.SetActive(true);
                       }
                       
                    
            
            if (Input.GetKeyDown(KeyCode.C)){
                int j=RelicApply();
                if (j!=-1){
                    if (Base.total_coin<objectData.price){
                        Debug.Log("돈없음");
                    }
                    else if (Base.total_coin>=objectData.price){
                        Base.total_coin-=objectData.price;
                        gameObject.SetActive(false);
                        M.SetActive(false);
                    }
                    
                    
                }
                
                //
            }
        }
    
    int RelicApply(){
        string Name=gameObject.name;
                if (objectData.RelicName==Name){
                    return objectData.price;

                }
                return -1;
    }
}

