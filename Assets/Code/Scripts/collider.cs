using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collider : MonoBehaviour
{
    public Text a;
    int i;
    int coin_num;
    NewBehaviourScript Base;
    BoxCollider boxcollider;
     Relic objectData;

    
     
    Transform t;
    // Start is called before the first frame update
    void Start()
    {
        string b=a.text;
        int coin_num=int.Parse(b);
        
        objectData = ScriptableObject.CreateInstance<Relic>();
        Base=GetComponent<NewBehaviourScript>();
        boxcollider=GetComponent<BoxCollider>();
        
       
    }
    // Update is called once per frame
    void Update()
    {
      
        
    }
    
    void OnTriggerStay(Collider col){
           if(col.gameObject.tag == "Player"){
            for (int i =1 ;i< 7;i++){
                 if (Base.relics[i]){
                  Base.Text[i].SetActive(true); 
                  Debug.Log("충돌");
                 }
              }
            int relicsApply(){
                if (col.gameObject.tag=="relics"){
                    string Name=col.gameObject.name;
                    if (objectData.RelicName==Name){
                        return objectData.price;
                    }
                
                }
                return -1;
            }
            if(Input.GetKeyDown(KeyCode.C)){
                int relicprice=relicsApply();
                if(coin_num>=relicprice){//총코인이 많을 경우
                      GameObject.FindWithTag("relics").SetActive(false);//사라지게 만듬
                      coin_num-=relicprice;//
                    }
                else{
                    Debug.Log("돈이 없음");//텍스트 띄우기
                }
                }
                
            
            }
        }
    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            Base.Text[i].SetActive(false);
        }

    }
   
}
