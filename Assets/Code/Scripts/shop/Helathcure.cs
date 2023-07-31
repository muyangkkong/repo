using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Helathcure : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    CharacterHP hp;
   

    void Awake()
    {
        player = GameObject.Find("Player");
        hp = player.GetComponent<CharacterHP>();
       
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            if (Input.GetKeyDown(KeyCode.C))
            {
               hp.getHeal(hp.maxHp);
                Destroy(gameObject);
            }
            
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
