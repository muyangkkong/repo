using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpSelect : MonoBehaviour
{
    
   
    // Start is called before the first frame update
     public GameObject player;
    public void Holding()
    {
          Debug.Log("click");
        player.SetActive(true);
    }
    public void Destoying(){
         GameObject.FindWithTag("Player").SetActive(false);
    }


    // Update is called once per frame
   
}
