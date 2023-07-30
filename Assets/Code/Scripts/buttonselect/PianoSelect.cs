using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoSelect : MonoBehaviour
{
    
    
   
    public GameObject player;

    // Start is called before the first frame update
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
