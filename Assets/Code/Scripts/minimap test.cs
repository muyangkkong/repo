using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class minimaptest : MonoBehaviour
{
    int width;
    int height;
    int[,] mapData;
    public int mapHeight;
    public int mapWidth;
    private GameObject[,] minimapobjects;
    private Image minimapImage;
    // Start is called before the first frame update
    void Start()
    {
        LoadMap();

        
        //맵 읽고 일단 미니맵에 표현하기
        //height=행
        //width=열
    }

    // Update is called once per frame
    void Update()
    {
        
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
                for ( int m =0 ;m<mapWidth;m++)
                {//읽어서 data로 할당한 다음에 돌아가면서 표현하면 되는데..
                    for ( int n =0 ;n<mapHeight;n++)
                    {
                        minimapobjects[m,n].GetComponent<Image>().color = (data == 0) ? Color.white : Color.black;
                    }
                }
            }
        }
        

        sr.Close();
        fs.Close();
    }
}
