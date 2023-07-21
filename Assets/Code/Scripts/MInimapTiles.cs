using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MInimapTiles : MonoBehaviour
{
    int mapWidth=14;
    int mapHeight=14;
    public Image minimapimage;
    GridLayoutGroup grid;
    GameObject cell;
    
    int [,] newarray;
    void Start()
    {
        newarray=new int[mapWidth,mapHeight];
        for ( int m =0 ;m<mapWidth;m++)
                {
                    for ( int n =0 ;n<mapHeight;n++)
                    {    
                        
                       if (m%2==0)
                       {
                          newarray[m,n]=0;
                       }
                        
                        if (newarray[m,n]==0)
                        {
                            int t=m+14*n;

                            Transform cell=grid.transform.GetChild(t);
                            Image cellObj=cell.GetComponent<Image>();
                            cellObj.color=Color.white;
                        }
                    }
    
                }
    }
}

