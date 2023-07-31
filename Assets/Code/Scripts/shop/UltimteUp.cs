using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimteUp : MonoBehaviour
{
    // Start is called before the first frame update
    //GameObject player;



    void Awake()
    {
     //   player = GameObject.Find("Player");
     

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.C))
            {
                UltimateGuageManager.Instance.AddValue(1000f);
                Destroy(gameObject);
            }

        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
