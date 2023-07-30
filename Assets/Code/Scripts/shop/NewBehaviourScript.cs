using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class NewBehaviourScript : MonoBehaviour
{
    

  //타일 박스 콜라이더로 지정..
   
    public GameObject[] relics;
    public GameObject[] music_note;
    
    public GameObject[] Text;
    GameObject instantiatedrelics;
    Rito.Demo.Test_WRandomPick testrandom;
    Rito.Demo.Test_WRandomPick1 testrandom1;
   
    public Text Total_coin;
    public string b;
    public int total_coin;
    
    
    
    
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
        Text[9]=GameObject.Find("Text").transform.Find("note(특수)바이올린1").gameObject;
        Text[10]=GameObject.Find("Text").transform.Find("note(특수)바이올린2").gameObject;
        Text[11]=GameObject.Find("Text").transform.Find("note(특수)바이올린3").gameObject;
        Text[12]=GameObject.Find("Text").transform.Find("note(특수)하프3").gameObject;
        Text[13]=GameObject.Find("Text").transform.Find("note(특수)하프2").gameObject;
        Text[14]=GameObject.Find("Text").transform.Find("note(특수)하프1").gameObject;
        Text[15]=GameObject.Find("Text").transform.Find("note(특수)피아노1").gameObject;
        Text[16]=GameObject.Find("Text").transform.Find("note(특수)피아노2").gameObject;
        Text[17]=GameObject.Find("Text").transform.Find("note(특수)피아노3").gameObject;
        Text[18]=GameObject.Find("Text").transform.Find("note(특수)트럼펫1").gameObject;
        Text[19]=GameObject.Find("Text").transform.Find("note(특수)트럼펫2").gameObject;
        Text[20]=GameObject.Find("Text").transform.Find("note(특수)트럼펫3").gameObject;
        Text[21]=GameObject.Find("Text").transform.Find("note(희귀)바이올린").gameObject;
        Text[22]=GameObject.Find("Text").transform.Find("note(희귀)하프").gameObject;
        Text[23]=GameObject.Find("Text").transform.Find("note(희귀)트럼펫").gameObject;
        Text[24]=GameObject.Find("Text").transform.Find("note(희귀)피아노").gameObject;


        //악보까지 넣어야 될듯
        
        
        b=Total_coin.text;
        total_coin=int.Parse(b);

        
        testrandom = GetComponent<Rito.Demo.Test_WRandomPick>();
        testrandom1 = GetComponent<Rito.Demo.Test_WRandomPick1>();
        testrandom.relics_random=new List<string>();
        testrandom1.relics_random=new List<string>();
        testrandom.Test();
        testrandom1.Test();
        
        
        Transforming();
        Transforming_music();
    }

    // Update is called once per frame
    void Update()
    {
       
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
    void Transforming_music(){
        foreach (GameObject j in music_note){
            if(j.name==testrandom1.relics_random[0]){
                GameObject instantiatedrelics = Instantiate(j);
                instantiatedrelics.transform.position=new Vector3(36,13,0);
             }
        }
        foreach (GameObject j in music_note){
            if(j.name==testrandom1.relics_random[1]){
                GameObject instantiatedrelics = Instantiate(j);
                instantiatedrelics.transform.position=new Vector3(39,8,0);
             }
        }
    }
}
