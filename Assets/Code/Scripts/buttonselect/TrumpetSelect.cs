using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpetSelect : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    
    // Update is called once per frame
    
    public void Holding()
    {
        Debug.Log("click");
        player.SetActive(true);
        
    }
    public void Destoying(){
        GameObject.FindWithTag("Player").SetActive(false);
    }

}
