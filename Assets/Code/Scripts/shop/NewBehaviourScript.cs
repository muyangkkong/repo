using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class NewBehaviourScript : MonoBehaviour
{
    GameObject instantiatedrelics;
    Rito.Demo.Test_WRandomPick testrandom;
    Rito.Demo.Test_WRandomPick1 testrandom1;
   
    
    
    public GameObject[] relics;
    public GameObject[] music_note;
    
    public void St()
    { 
        GameObject[] relics= Resources.LoadAll<GameObject>("relic2d/");
        GameObject[] music_note= Resources.LoadAll<GameObject>("score/");

        Rito.Demo.Test_WRandomPick testrandom = GetComponent<Rito.Demo.Test_WRandomPick>();
        Rito.Demo.Test_WRandomPick1 testrandom1 = GetComponent<Rito.Demo.Test_WRandomPick1>();
        
        testrandom.relics_random=new List<string>();
        testrandom1.relics_random=new List<string>();
        
        testrandom.Test();
        testrandom1.Test();
        
        foreach (GameObject j in relics){
            
            
            if(j.name==testrandom.relics_random[0]){
                Debug.Log(testrandom.relics_random[0]);
                GameObject instantiatedrelics = Instantiate(j);
                instantiatedrelics.transform.position=new Vector3(7,15,0);
            }
            else if (j.name==testrandom.relics_random[1]){
                Debug.Log(testrandom.relics_random[1]);
                GameObject instantiatedrelics = Instantiate(j);
                instantiatedrelics.transform.position=new Vector3(17,10,0);
            }
            else if (j.name==testrandom.relics_random[2]){
                Debug.Log(testrandom.relics_random[2]);
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
        
    

    // Update is called once per frame
    void Update()
    {
       
    }

    
    
    
    
       
    }
   

