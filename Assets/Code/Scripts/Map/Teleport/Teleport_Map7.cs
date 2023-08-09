using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Map7 : MonoBehaviour
{
    GameObject maincam;
    MainCamera cam;
    GameObject maincan;
    CanvasManager can;
    GameObject targetplayer;
    PlayerMovement move;
    NewBehaviourScript Base;
    // Start is called before the first frame update
    void Start()
    {
        maincam = GameObject.Find("Main Camera");
        cam = maincam.GetComponent<MainCamera>();
        maincan = GameObject.Find("Canvas");
        can = maincan.GetComponent<CanvasManager>();
        targetplayer = GameObject.Find("Player");
        move = targetplayer.GetComponent<PlayerMovement>();
        Base=GameObject.Find("Canvas").GetComponent<NewBehaviourScript>();
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
            MapManager.Instance.LoadMap(7);
            MapManager.Instance.BuildMap();
            Minimap.Instance.LoadMap(7);
            Minimap.Instance.FindingPlayer();
            Minimap.Instance.UpdateMiniMap();
            Minimap.Instance.Init();
            Background.Instance.DestroyBack();
            Background.Instance.BuildBack(6);
            can.Activate();
            cam.limitMaxX = 49.5f;
            cam.limitMaxY = 21f;
            Base.St();
            
            //Debug.Log(map.gameObject.GetInstanceID());
        }

    }
}
