using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject Player;
    public GameObject[] enemies;
    int width;
    int height;
    int tileSize = 1;
    int[,] mapData;
    private static MapManager instance = null;
    BossStage bossStage;
    NewBehaviourScript Base;

    void Awake()
    {
        if (null == instance)
        {
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, 
            //���� �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� GameMgr)�� �������ش�.
            Destroy(this.gameObject);
        }
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
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

        LoadMap(1);
        PlayerPrefs.SetInt("time",0);
        BuildMap();
        Debug.Log(gameObject.GetInstanceID());
        bossStage = GetComponent<BossStage>();
        bossStage.enabled = false;
        PlayerEquipment playerEquipment = GameObject.FindWithTag("Player").GetComponent<PlayerEquipment>();
        if(SelectDiliver.Instance?.Select != null)
            playerEquipment.instrument = SelectDiliver.Instance.Select;
        playerEquipment.EquipInstrument();
        
    }
    

    public void LoadMap(int id) {

        //FileStream fs = new FileStream(Resources.Load("Map\\"+id) as TextAsset, FileMode.Open, FileAccess.Read);
        TextAsset asset = Resources.Load("Map\\"+id) as TextAsset;
        Stream st = new MemoryStream(asset.bytes);
        StreamReader sr = new StreamReader(st);

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
        st.Close();
    }
    
    public void BuildMap() {
        for(int j = 0; j < height; j++) {
            for(int i = 0; i < width; i++) {
                if(mapData[j,i] == -1) {
                    //Player.transform.position = new Vector3(i * tileSize, (height - j) * tileSize, 0);
                    GameObject.FindWithTag("Player").transform.position = new Vector3(i * tileSize, (height - j) * tileSize, 0);
                }
                if (mapData[j, i] > 0 && mapData[j, i] < 50)
                {
                    Instantiate(tiles[mapData[j, i]], new Vector3(i * tileSize, (height - j) * tileSize, 0), Quaternion.identity).transform.SetParent(this.transform);
                }
                if (mapData[j, i] >= 1000)
                {
                    Instantiate(enemies[mapData[j, i] % 1000], new Vector3(i * tileSize, (height - j) * tileSize, 0), Quaternion.identity).transform.SetParent(this.transform);
                // %1000 = 0,1...
                }
            }
        }
    }

    public void DestroyMap() {
        Transform[] childList = GetComponentsInChildren<Transform>();
        GameObject[] all1=GameObject.FindGameObjectsWithTag("relics");
        GameObject[] all2=GameObject.FindGameObjectsWithTag("teleport");
        GameObject[] all3=GameObject.FindGameObjectsWithTag("note");
        for (int i=0;i<all1.Length;i++){
            Destroy(all1[i]);
        }
        for (int i=0;i<all2.Length;i++){
            Destroy(all2[i]);
        }
        
        for (int i=0;i<all3.Length;i++){
            Destroy(all3[i]);
        }
        
        Debug.Log("destroy\n");
        if(childList != null){
            Debug.Log("Children is not Null");
            for(int i = 1; i < childList.Length; i++) {
                if(childList[i] != transform) Destroy(childList[i].gameObject);
            }
        }
        
    }

    public void BossStageStart() {
        bossStage.enabled = true;
    }
}