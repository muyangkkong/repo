using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class minimap : MonoBehaviour
{
    int width;
    int height;
     int[,] mapData;
     int [,] newarray;
    int mapHeight=14;
    int mapWidth=14;
    public GameObject player;
    
    
    int a;
    int b;

    Vector3 posi;
    RectTransform rectTransform;
   
    
    public GridLayoutGroup grid;
    public Image cellPrefab;
    
    
    
    // Start is called before the first frame update
    void Start()
    { 
        
        LoadMap(2);
        FindingPlayer();
        UpdateMiniMap();
        for(int j = 0; j < height; j++) {
            for(int i = 0; i < width; i++) {
                if (mapData[j,i]==-1)
                {
                    mapData[j,i]=0;
                }
            }
        }
       
        
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
            mapData[height-a-1,b]=0;
            player.transform.hasChanged = false;
        }

        
       
    }
    void UpdateMiniMap()
    {
        
    
        for ( int m =0 ;m<mapWidth;m++)
                {
                    for ( int n =0 ;n<mapHeight;n++)
                    {       //그 
                        Image cell = Instantiate(cellPrefab, grid.transform);
                        cell.rectTransform.localPosition = new Vector3(m * 10, n * 10, 0);
                        
                        if (newarray[m,n]==0)
                        {
                                cell.color=Color.black;
                                
                        }
                        else if (newarray[m,n]==-1) {
                            cell.color=Color.red;
                        }
                        else
                        {
                            cell.color=Color.white;
                                
                        }  
                    }
                }
        
        
    }
    public void LoadMap(int id) {
        FileStream fs = new FileStream("Assets\\Map\\"+id, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
       
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
        fs.Close();
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
        b = Mathf.FloorToInt(posi.x);//(23
        a = Mathf.FloorToInt(posi.y);//8  mapData[j 12,i 23]
        //파일 열고 다시 쓰기
        
        mapData[height-a-1,b]=-1;
        
        
        
    }
    
}
        
       
    

  //플레이어가 맵을 벗어나버리면 오류가 뜬다 이건 좀 찾아야할듯..
  //맵이 사라지는 마법..

