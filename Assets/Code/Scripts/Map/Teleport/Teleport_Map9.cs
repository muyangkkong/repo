using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Map9 : MonoBehaviour
{
    GameObject maincam;
    MainCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        maincam = GameObject.Find("Main Camera");
        cam = maincam.GetComponent<MainCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          
            MapManager.Instance.DestroyMap();
            MapManager.Instance.LoadMap(9);
            MapManager.Instance.BuildMap();
            Minimap.Instance.LoadMap(9);
            Minimap.Instance.FindingPlayer();
            Minimap.Instance.UpdateMiniMap();
            Minimap.Instance.Init();
            cam.limitMaxX = 99.5f;
            cam.limitMaxY = 21f;
            //Debug.Log(map.gameObject.GetInstanceID());
        }

    }
}
