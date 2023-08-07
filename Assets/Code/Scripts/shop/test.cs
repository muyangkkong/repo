using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
     GameObject effect;
     Text textobject;
    public string Message;
    public int objectprice;
     Text texttotalcoin;
    int total_coin;
    string b;
    Relic objectData;
    
    // Start is called before the first frame update
    void Start()
    {
        
        objectData = ScriptableObject.CreateInstance<Relic>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    void OnTriggerStay(Collider col){
        if (col.gameObject.tag=="Player"){
            GameObject effect = GameObject.Find("Canvas").transform.Find("effect").gameObject;
            effect.SetActive(true);
            Text textobject=GameObject.Find("effecttext").GetComponent<Text>();
            textobject.text=Message;
            effect.transform.localPosition=new Vector3(gameObject.transform.position.x,gameObject.transform.position.y-20,0);
            Text texttotalcoin=GameObject.Find("textcoin").GetComponent<Text>();
            string b= texttotalcoin.text;
            int total_coin=int.Parse(b);
            if (Input.GetKeyDown(KeyCode.C)){  
                
                if (total_coin>=objectprice){
                    gameObject.SetActive(false);
                    effect.gameObject.SetActive(false); 
                    texttotalcoin.text=(total_coin-objectprice).ToString();
                }
                else{
                     Debug.Log("돈 없음");
                }                    
                                }
            }
    }
       
    
         
    void OnTriggerExit(Collider col){
              if (col.gameObject.tag=="Player"){
                GameObject effect = GameObject.Find("Canvas").transform.Find("effect").gameObject;
                effect.gameObject.SetActive(false);
                             
                 }
                 
              }
         
    
    /*        if (Input.GetKeyDown(KeyCode.C)){
                int j=RelicApply();
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
        } */
    
    
 } 
/*     int RelicApply(){
        string Name=gameObject.name;
                if (objectData.RelicName==Name){
                    return objectData.price;

                }
                return -1;
    } */


