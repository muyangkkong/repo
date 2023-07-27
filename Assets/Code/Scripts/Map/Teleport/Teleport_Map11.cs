using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Map11 : MonoBehaviour
{
    GameObject maincam;
    MainCamera cam;
    GameObject maincan;
    CanvasManager can;
    // Start is called before the first frame update
    void Start()
    {
        maincam = GameObject.Find("Main Camera");
        cam = maincam.GetComponent<MainCamera>();
        maincan = GameObject.Find("Canvas");
        can = maincan.GetComponent<CanvasManager>();
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
            MapManager.Instance.DestroyMap();
            MapManager.Instance.LoadMap(11);
            MapManager.Instance.BuildMap();
            Minimap.Instance.LoadMap(11);
            Minimap.Instance.FindingPlayer();
            Minimap.Instance.UpdateMiniMap();
            Minimap.Instance.Init();
            Background.Instance.DestroyBack();
            Background.Instance.BuildBack(5);
            can.Activate();
            cam.limitMaxX = 49.5f;
            cam.limitMaxY = 21f;
            //Debug.Log(map.gameObject.GetInstanceID());
        }

    }
}
