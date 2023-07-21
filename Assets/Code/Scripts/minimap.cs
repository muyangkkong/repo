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
    public int mapHeight;
    public int mapWidth;
    public GameObject player;
  
    
     Image[,] minimapobject;
     
     GameObject cell;
    
    

    public Image front;
    
    GridLayoutGroup grid;

    
    
    
    // Start is called before the first frame update
    void Start()
    { 
        
        front.rectTransform.sizeDelta=new Vector2(mapWidth*10,mapHeight*10);
        //미니맵의 총크기를 newarray의 배열 크기에 맞춤(grid cell의 크기를 newarray의 열,행 크기에따라 맞춤)
        LoadMap();
        FindingPlayer();
        UpdateMiniMap();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        FindingPlayer();
        if (player.transform.hasChanged)
        {
            
            UpdateMiniMap();
            player.transform.hasChanged = false;
        }
    }
    void UpdateMiniMap()
    {
        
        

        for ( int m =0 ;m<mapWidth;m++)
                {
                    for ( int n =0 ;n<mapHeight;n++)
                    {    
                        
                        if (newarray[m,n]==0)
                        {
                            int t=m+14*n;
                            //newarray의 값이 0이면 게임 오브젝트 cell를 newarray의 위치에 맞게 grid 칸에 위치 변경(gridlayoutgroup컴포넌트는 미니맵 이미지에 맞게 되어있음)
                            Transform cell=grid.transform.GetChild(t);
                            // 이미지 컴포넌트를  cell에 갖고옴
                            Image cellObj=cell.GetComponent<Image>();
                            // 검은 색으로 바꿈
                            cellObj.color=Color.black;
                        }
                        
                        else
                        {
                            int t=m+14*n;

                            Transform cell=grid.transform.GetChild(t);
                            Image cellObj=cell.GetComponent<Image>();
                            cellObj.color=Color.white;
                        }
                        
                        

                        
                    }
                }
        
    }
    public void LoadMap() {
        FileStream fs = new FileStream("Assets\\Map\\2", FileMode.Open, FileAccess.Read);
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
    
     
    void FindingPlayer(){
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
       for (int x = j - halfWidth; x < j + halfHeight; x++)
       {
          for (int y = i - halfHeight; y < i + halfWidth; y++)
          {
            // 맵 파일의 플레이어 위치를 중심으로 newarray 배열의 크기만큼 값을 확인함
            for ( int m =0 ;m<mapWidth;m++)
            {
                for ( int n =0 ;n<mapHeight;n++)
                {    
                    if (x < 0 ||  y < 0 )
                    {
                       newarray[m, n]=0;//x,y가 음수가 되면 배경이라 생각함
                    }

                    newarray[m, n] = mapData[x, y];//newarray의 값을 mapData의 값으로 할당

            
                }
            
            }
          }
        }
       

    }

  //
}
