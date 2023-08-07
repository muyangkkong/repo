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
    
    
    GameObject instantiatedrelics;
    Rito.Demo.Test_WRandomPick testrandom;
    Rito.Demo.Test_WRandomPick1 testrandom1;
   
    public Text Total_coin;
    public string b;
    public int total_coin;
    
    
    
    
    // Start is called before the first frame update
    
    void Start()
    { 
       

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
                instantiatedrelics.transform.position=new Vector3(7,15,0);
                
                
            }
            else if (j.name==testrandom.relics_random[1]){
                GameObject instantiatedrelics = Instantiate(j);
                instantiatedrelics.transform.position=new Vector3(17,10,0);
                
            }
            else if (j.name==testrandom.relics_random[2]){
                GameObject instantiatedrelics = Instantiate(j);
                instantiatedrelics.transform.position=new Vector3(26,15,0);
                
                
            }
            else if (j.name =="Red_potion"){
                GameObject instantiatedrelics = Instantiate(j);
                instantiatedrelics.transform.position=new Vector3(26,7,0);
            }
            else if (j.name =="Green_potion"){
                GameObject instantiatedrelics = Instantiate(j);
                instantiatedrelics.transform.position=new Vector3(8,7,0);
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
