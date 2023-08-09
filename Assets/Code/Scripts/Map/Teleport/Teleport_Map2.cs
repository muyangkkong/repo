using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Map2 : MonoBehaviour
{
    
    
    GameObject maincam;
    MainCamera cam;
    GameObject maincan;
    CanvasManager can;
    GameObject targetplayer;
    PlayerMovement move;
    // Start is called before the first frame update
    void Awake()
    {
        maincam = GameObject.Find("Main Camera");
        cam = maincam.GetComponent<MainCamera>();
        maincan = GameObject.Find("Canvas");
        can = maincan.GetComponent<CanvasManager>();
        targetplayer = GameObject.Find("Player");
        move = targetplayer.GetComponent<PlayerMovement>();
        PlayerPrefs.SetInt("time",0);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            can.Setting();
            move.speed = 0f;
            MapManager.Instance.DestroyMap();
            MapManager.Instance.LoadMap(2);
            MapManager.Instance.BuildMap();
            Minimap.Instance.LoadMap(2);
            Minimap.Instance.FindingPlayer();
            Minimap.Instance.UpdateMiniMap();
            Minimap.Instance.Init();
            can.Activate();
            cam.limitMaxX = 99.5f;
            cam.limitMaxY = 21f;
            //move.speed = 10.0f;
            //Debug.Log(map.gameObject.GetInstanceID());
             PlayerPrefs.SetInt("time",2);
            
        }

    }
}
