using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    NewBehaviourScript Base;
    
    public int price;
    private GameObject m;
    // Start is called before the first frame update
    void Start()
    {
        
        Base=GameObject.Find("Canvas").transform.GetComponent<NewBehaviourScript>();
        Debug.Log(Base.total_coin);
       
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
                
                
                    if (Base.total_coin<price){
                        Debug.Log("돈없음");//텍스트 띄우기
                    }
                    else if (Base.total_coin>=price){
                        int number=Base.total_coin-=price;
                        Base.b=number.ToString();
                        Base.Total_coin.text=Base.b;
                       
                        gameObject.SetActive(false);
                        m.SetActive(false);
                    }
                    
                    
                
                
                //
            }
        }
    }
    
    
}

