using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapManager1 : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject Player;
    int width;
    int height;
    int tileSize = 1;
    int[,] mapData;

    
    
    void Start() {
        LoadMap();
        BuildMap();
    }
    

    public void LoadMap() {
        FileStream fs = new FileStream("Assets\\Map\\4", FileMode.Open, FileAccess.Read);
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

    
}
