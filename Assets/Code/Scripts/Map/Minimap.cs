using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using JetBrains.Annotations;

public class Minimap : MonoBehaviour
{
    int width;
    int height;
     int[,] mapData;
     int [,] newarray;
    int mapHeight=14;
    int mapWidth=14;
    int previous1;
    int previous2;
    public GameObject player;
 
    
    
    int a;
    int b;
    Vector3 posi;
    RectTransform rectTransform;
   
    
    public GridLayoutGroup grid;
    public Image cellPrefab;

    private static Minimap instance = null;

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
    public static Minimap Instance
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


    // Start is called before the first frame update
    void Start()
    { 
        
        LoadMap(1);
        FindingPlayer();
        UpdateMiniMap();
        Init();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.transform.hasChanged)
        {
            foreach(Transform child in grid.transform )
            {
                Destroy(child.gameObject);
            }
            
            
            Playermove();
            FindingPlayer();
            UpdateMiniMap();
            mapData[height-a-1,b]=previous1;
            mapData[height-a-2,b]=previous2;
            player.transform.hasChanged = false;
        }

        
       
    }
    public void UpdateMiniMap()
    {
        
    
        for ( int m =0 ;m<mapWidth;m++)
                {
                    for ( int n =0 ;n<mapHeight;n++)
                    {       //그 
                        Image cell = Instantiate(cellPrefab, grid.transform);
                        cell.rectTransform.localPosition = new Vector3(m * 10, n * 10, 0);
                        
                        if (newarray[m,n]==0 || newarray[m, n] == 7 || newarray[m, n] == 23 || newarray[m, n] == 24 || newarray[m, n] == 25 || newarray[m, n] == 26 || newarray[m, n] == 27 || newarray[m, n] == 28 || newarray[m, n] == 29 || newarray[m, n] == 30 || newarray[m,n] >=1000)
                        {
                                cell.color=Color.black;
                                Color newColor = cell.color;
                                newColor.a = 0.3f;
                                cell.color = newColor;
                    
                                
                        }
                        else if (newarray[m,n]==-1) {
                            cell.color=Color.red;
                        }
                        else if (newarray[m, n] == 9 || newarray[m, n] == 10 || newarray[m, n] ==11 || newarray[m, n] == 12 || newarray[m, n] == 13 || newarray[m, n] == 14 || newarray[m, n] == 15 )
                         {
                    cell.color = Color.cyan ;
                         }
                        else
                        {
                            cell.color=Color.white;
                                
                        }  
                    }
        }
        
        
    }
    public void LoadMap(int id) {
        TextAsset asset = Resources.Load("Map\\"+id) as TextAsset;
        Stream st = new MemoryStream(asset.bytes);
        StreamReader sr = new StreamReader(st);
       
        string[] s = sr.ReadLine().Split(" ", System.StringSplitOptions.None);
        if(s.Length != 2) {
            
            return;
        }
        width = int.Parse(s[0]);
        height = int.Parse(s[1]);
        
        mapData = new int[height, width];
        for(int j = 0; j < height; j++) {
            s = sr.ReadLine().Split(" ", System.StringSplitOptions.None);
            if(s.Length != width) {
                
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
    
     
    public void FindingPlayer(){
       //map파일 안의 플레이어 위치를 찾으면 함수 실행

        for(int j = 0; j < height; j++) 
        {
            for(int i = 0; i < width; i++) 
            {
                if(mapData[j,i] == -1) 
                {
                    
                    NewArray(j,i);
                    
                }
            }
        }

    }
    public void NewArray(int j,int i)
    {
      
       int halfWidth = mapWidth / 2;
       int halfHeight = mapHeight / 2;
       newarray = new int[mapWidth, mapHeight];
       
       
       //newarray 배열을 [mapwidth,mapHeight]크기로 정함
       for (int x = j - halfWidth,m=0; x < j + halfHeight; m++,x++)
       {
          for (int y = i - halfHeight,n=0; y < i + halfWidth; n++,y++)
           {
            // 맵 파일의 플레이어 위치를 중심으로 newarray 배열의 크기만큼 값을 확인함
              
                    if (x >= 0 && y >= 0 && x < height && y < width)
                    {
                          newarray[m, n] = mapData[x, y]; // 세로 가로
                    }
                    else
                    {
                         newarray[m, n] = 0; // x, y가 음수이거나 맵 범위를 벗어나면 배경으로 설정
                    }
                    
                    
           }
            
        }
        
            
    }
     void Playermove()
    { 
        
        posi=player.transform.position;        
        b = Mathf.FloorToInt(posi.x+0.5f);//(23
        a = Mathf.FloorToInt(posi.y+0.1f)-1;//8  mapData[j 12,i 23]
        //파일 열고 다시 쓰기
        previous1 = mapData[height - a - 1, b];
        previous2 = mapData[height - a - 2, b];
        mapData[height-a-1,b]=-1;
        mapData[height-a-2,b]=-1;
        
        
        
    }

    public void Destroy()
    {
        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                
                    mapData[j, i] = 0;
                
            }
        }
        
    }
    public void Init()
    {

        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                if (mapData[j, i] == -1)
                {
                    mapData[j, i] = 0;
                }
            }
        }

    }
    
}
        
       
    

  //플레이어가 맵을 벗어나버리면 오류가 뜬다 이건 좀 찾아야할듯..
  //맵이 사라지는 마법..
  //은 너굴맨이 해치웠으니 걱정말라구

