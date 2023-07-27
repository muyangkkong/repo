using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class NewBehaviourScript : MonoBehaviour
{
    

  //타일 박스 콜라이더로 지정..
   
    public GameObject[] relics;
    
    public GameObject[] Text;
    GameObject instantiatedrelics;
    Rito.Demo.Test_WRandomPick testrandom;
    BoxCollider boxcollider;
    public Text Total_coin;
    public string b;
    public int total_coin;
    public Relic relicobjects;
    
    
    
    // Start is called before the first frame update
    
    void Start()
    { 
       for (int i=0;i<Text.Length;i++){
        Text[i].SetActive(false);
       }
        Text[0]=GameObject.Find("Text").transform.Find("4clover").gameObject;
        Text[1]=GameObject.Find("Text").transform.Find("100_Score").gameObject;
        Text[2]=GameObject.Find("Text").transform.Find("Beer").gameObject;
        Text[3]=GameObject.Find("Text").transform.Find("Blue_potion").gameObject;
        Text[4]=GameObject.Find("Text").transform.Find("Clock").gameObject;
        Text[5]=GameObject.Find("Text").transform.Find("Heart").gameObject;
        Text[6]=GameObject.Find("Text").transform.Find("Money_bag").gameObject;
        Text[7]=GameObject.Find("Text").transform.Find("Green_potion").gameObject;
        Text[8]=GameObject.Find("Text").transform.Find("Red_potion").gameObject;
        
        b=Total_coin.text;
        total_coin=int.Parse(b);

        
        testrandom = GetComponent<Rito.Demo.Test_WRandomPick>();
        testrandom.relics_random=new List<string>();
        testrandom.Test();
        
        Transforming();
    }

    // Update is called once per frame
    void Update()
    {
        b=Total_coin.text;
    }

    
    
    void Transforming(){
        
        foreach (GameObject j in relics){
            
            
            if(j.name==testrandom.relics_random[0]){
                GameObject instantiatedrelics = Instantiate(j);
                instantiatedrelics.transform.position=new Vector3(7,16,0);
                
                
            }
            else if (j.name==testrandom.relics_random[1]){
                GameObject instantiatedrelics = Instantiate(j);
                instantiatedrelics.transform.position=new Vector3(17,11,0);
                
            }
            else if (j.name==testrandom.relics_random[2]){
                GameObject instantiatedrelics = Instantiate(j);
                instantiatedrelics.transform.position=new Vector3(26,16,0);
                
                
            }
            else if (j.name =="Red_potion"){
                GameObject instantiatedrelics = Instantiate(j);
                instantiatedrelics.transform.position=new Vector3(26,8,0);
            }
            else if (j.name =="Green_potion"){
                GameObject instantiatedrelics = Instantiate(j);
                instantiatedrelics.transform.position=new Vector3(8,8,0);
            }
            
            
        }
    
       
    }
    //
    
}
