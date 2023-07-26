using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Map2 : MonoBehaviour
{
    public MapManager map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            map.LoadMap(2);
            map.DestroyMap();
            map.BuildMap();
        }

    }
}
