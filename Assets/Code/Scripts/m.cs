using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class m : MonoBehaviour
{
    public GameObject player;
    public GameObject minimapPlayer;
    public int mapHeight;
    public int mapWidth;
    private int[,] mapData;
    private GameObject[,] minimapObjects;
    private Image minimapImage;

    void Start()
    {
        LoadMap(2);
        InitializeMiniMap();
        UpdateMiniMap();
    }

    public void LoadMap(int id)
    {
        string filePath = "Assets\\Map\\" + id;
        StreamReader sr = new StreamReader(filePath);

        string[] s = sr.ReadLine().Split(" ", System.StringSplitOptions.None);
        if (s.Length != 2)
        {
            Debug.LogError("Parse Error : (width, height) data format error");
            return;
        }

        mapWidth = int.Parse(s[0]);
        mapHeight = int.Parse(s[1]);

        mapData = new int[mapHeight, mapWidth];
        for (int j = 0; j < mapHeight; j++)
        {
            s = sr.ReadLine().Split(" ", System.StringSplitOptions.None);
            if (s.Length != mapWidth)
            {
                Debug.LogError("Parse Error : data does not match width");
                return;
            }
            for (int i = 0; i < mapWidth; i++)
            {
                int data = int.Parse(s[i]);
                mapData[j, i] = data;
            }
        }

        sr.Close();
    }

    void InitializeMiniMap()
    {
        minimapObjects = new GameObject[mapHeight, mapWidth];

        // Instantiate and position minimap tiles
        for (int x = 0; x < mapHeight; x++)
        {
            for (int y = 0; y < mapWidth; y++)
            {
                // Create a new GameObject for each tile and set its position
                GameObject minimapTile = new GameObject("MinimapTile_" + x + "_" + y);
                minimapTile.transform.SetParent(transform);
                minimapTile.transform.localPosition = new Vector3(x, y, 0);

                // Add Image component to the GameObject and set its color
                Image minimapImage = minimapTile.AddComponent<Image>();
                minimapImage.color = (mapData[x, y] == 0) ? Color.white : Color.black;

                minimapObjects[x, y] = minimapTile;
            }
        }
    }

    void UpdateMiniMap()
    {
        int playerPosX = Mathf.FloorToInt(player.transform.position.x);
        int playerPosY = Mathf.FloorToInt(player.transform.position.y);
        minimapPlayer.transform.localPosition = new Vector3(playerPosX, playerPosY, 0);
    }
}
