using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class NewBehaviourScript : MonoBehaviour
{
    public GameObject player;

    
    Vector3 posi;
    public GameObject[] relics;
    public GameObject[] Text;

    int i;
    Rito.Demo.Test_WRandomPick testrandom;
    

    
    //텍스트를 일일이 유물에 대입해야함.

    BoxCollider boxcollider;
    // Start is called before the first frame update
    void Start()
    { 
        testrandom = GetComponent<Rito.Demo.Test_WRandomPick>();
        Transforming();

        
        boxcollider= GetComponent<BoxCollider>();
        foreach (GameObject obj in Text){
        obj.SetActive(false);
        }
        foreach (GameObject obje in relics){
        obje.SetActive(false);
    }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(BoxCollider col){
        if(col.tag == "Player"){
            
        for (int i =1 ;i< 10;i++)
        if (relics[i]){
        Text[i].SetActive(true); 

        }

        }
    }
    public void OnTriggerExit(BoxCollider col){
        if(col.tag=="Player"){
            Text[i].SetActive(false);
        }
    }
    void Transforming(){
        for (int m =0;m<testrandom.relics_random.Count;m++ ){
            GameObject.Find(testrandom.relics_random[m]).SetActive(true);
        }
        
        GameObject.Find(testrandom.relics_random[0]).transform.position=new Vector3(7,15,0);//collider위치에 y+1
        GameObject.Find(testrandom.relics_random[1]).transform.position=new Vector3(17,10,0);
        GameObject.Find(testrandom.relics_random[2]).transform.position=new Vector3(26,15,0);
        //랜덤 아이템 3개 나왔으니  그걸 다른 transform 함
    }
    
}
