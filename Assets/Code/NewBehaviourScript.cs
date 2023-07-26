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

    public string coin_nu;
    public int coin_num;
    Rito.Demo.Test_WRandomPick testrandom;
    

    
    

    BoxCollider boxcollider;
    // Start is called before the first frame update
    void Start()
    { 
        testrandom = GetComponent<Rito.Demo.Test_WRandomPick>();
        Transforming();
        int coin_num=int.Parse(coin_nu);
        
        
        foreach (GameObject obj in Text){
        obj.SetActive(false);
        }
        foreach (GameObject obje in relics){
        obje.SetActive(false);
        }
        testrandom.Test();
        Debug.Log(testrandom.relics_random.Count);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
    void Transforming(){
        
        foreach (GameObject j in relics){
            if(j.name==testrandom.relics_random[0]){
                j.transform.position=new Vector3(7,15,0);
            }
            else if (j.name==testrandom.relics_random[1]){
                j.transform.position=new Vector3(17,10,0);
            }
            else if (j.name==testrandom.relics_random[2]){
                j.transform.position=new Vector3(26,15,0);
            }
        }
       
    }
    //
    
}
