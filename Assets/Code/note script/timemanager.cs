using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timemanager : MonoBehaviour
{
    public List<GameObject>boxNoteList=new List<GameObject>();
    [SerializeField]Transform Center=null;
    [SerializeField]RectTransform[] timingRect=null;
    Vector2[]timingBoxs=null;
    
    // Start is called before the first frame update
    void Start()
    {
        timingBoxs=new Vector2[timingRect.Length];
        for(int i =0;i<timingRect.Length;i++)
        {
            timingBoxs[i].Set(Center.localPosition.x-timingRect[i].rect.width/2,
                              Center.localPosition.x+timingRect[i].rect.width/2);
            Debug.Log(timingBoxs[i]);               
        }
        GameObject perfect = GameObject.Find("perfect");
        perfect.SetActive(false);
        
    }

    // Update is called once per frame
    public void CheckingTiming()
    {
        for (int i=0; i<boxNoteList.Count; i++)
        {
            float t_notePosX=boxNoteList[i].transform.localPosition.x;
            
            for(int x =0;x<timingBoxs.Length;x++)
            {
                if(timingBoxs[x].x<= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    Destroy(boxNoteList[i]);
                    boxNoteList.RemoveAt(i);
                    Debug.Log("Hit"+x);
                    return;
                }
            }
        
        }
        Debug.Log("Miss");
        
    }
}