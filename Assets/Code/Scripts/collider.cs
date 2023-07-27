using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collider : MonoBehaviour
{
    
    NewBehaviourScript Base;
    Collider interactionCollider;
    
     Relic objectData;
    public Text atm;
      string  b;

   
    
    float shortDis;
    
    public GameObject[] Text;
    
    GameObject m;
    Vector2 createpoint;
    int coin_num;
    
    
    // Start is called before the first frame update
    void Start()
    {
        atm=GetComponent<Text>();
        string b=atm.text;
        int coin_num=int.Parse(b);
        objectData = ScriptableObject.CreateInstance<Relic>();
        Text= GameObject.FindGameObjectsWithTag("text");
        foreach (GameObject uiElement in Text)
        {
            uiElement.SetActive(false);
        }
        
        
      
        
       
        
        
        
        
        
    }
    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.C)) // "C" 키를 눌렀을 때
        {
            if (IsPlayerInsideCollider()) // 플레이어가 콜라이더 안에 있는지 확인
            { 
                int relicprice=relicsApply();
                if(coin_num>=relicprice){//총코인이 많을 경우
                      //이물체.SetActive(false);//사라지게 만듬
                      coin_num-=relicprice;
                      gameObject.SetActive(false);//

                }
                else{
                    Debug.Log("돈이 없음");//텍스트 띄우기
                }
            }
        
        }
    }
    bool IsPlayerInsideCollider()
    {
        Collider[] colliders = Physics.OverlapBox(interactionCollider.bounds.center, interactionCollider.bounds.extents, Quaternion.identity);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player")) // 플레이어 태그를 가진 콜라이더와 충돌했는지 확인
            {
                return true;
            }
        }

        return false;
    }
    
    void OnTriggerEnter(Collider col){
           if (col.gameObject.tag=="Player"){
                    foreach (GameObject m in Text){
                                
                                if (m.name==gameObject.name){
                                    m.SetActive(true);
                                    
                                }
                             
                              }
                             //relics
                    }
                             
                    
                    
                    
                } 
     
    void OnTriggerExit(Collider col){
              if (col.gameObject.tag=="Player"){
                foreach (GameObject m in Text){
                                
                                if (m.name==transform.name){
                                    m.SetActive(false);
                                    
                                }
                             
                              }
                 
              }
    }
    int relicsApply(){
        
                
                    string Name=gameObject.name;
                    if (objectData.RelicName==Name){
                        return objectData.price;
                    }
                
                
                return -1;
            }
                
}
                      

            
    
    
    
        
        
    
   
    
   

