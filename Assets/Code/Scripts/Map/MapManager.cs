using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject Player;
    int width;
    int height;
    int tileSize = 1;
    int[,] mapData;
    private static MapManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static MapManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }



    void Start() {

        LoadMap(6);
        BuildMap();
        Debug.Log(gameObject.GetInstanceID());
    }
    

    public void LoadMap(int id) {
        FileStream fs = new FileStream("Assets\\Map\\"+id, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);

        string[] s = sr.ReadLine().Split(" ", System.StringSplitOptions.None);
        if(s.Length != 2) {
            Debug.LogError("Parse Error : (width, height) data format error");
            return;
        }
        width = int.Parse(s[0]);
        height = int.Parse(s[1]);
        
        mapData = new int[height, width];
        for(int j = 0; j < height; j++) {
            s = sr.ReadLine().Split(" ", System.StringSplitOptions.None);
            if(s.Length != width) {
                Debug.Log(s.Length);
                Debug.LogError("Parse Error : data does not match width");
                return;
            }
            for(int i = 0; i < width; i++) {
                int data = int.Parse(s[i]);
                mapData[j,i] = data;
            }
        }

        sr.Close();
        fs.Close();
    }
    
    public void BuildMap() {
        for(int j = 0; j < height; j++) {
            for(int i = 0; i < width; i++) {
                if(mapData[j,i] == -1) {
                    //Player.transform.position = new Vector3(i * tileSize, (height - j) * tileSize, 0);
                    GameObject.FindWithTag("Player").transform.position = new Vector3(i * tileSize, (height - j) * tileSize, 0);
                }
                if(mapData[j,i] > 0) {
                    Instantiate(tiles[mapData[j,i]], new Vector3(i * tileSize, (height - j) * tileSize, 0), Quaternion.identity).transform.SetParent(this.transform);
                }
            }
        }
    }

    public void DestroyMap() {
        Transform[] childList = GetComponentsInChildren<Transform>();
        Debug.Log("destroy\n");
        if(childList != null){
            Debug.Log("Children is not Null");
            for(int i = 1; i < childList.Length; i++) {
                if(childList[i] != transform) Destroy(childList[i].gameObject);
            }
        }
    }
}