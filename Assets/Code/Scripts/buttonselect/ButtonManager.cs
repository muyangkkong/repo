using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] pp;
    // Start is called before the first frame update
    void Start()
    {
        pp=GameObject.FindGameObjectsWithTag("Player");
        for (int i=0;i<pp.Length;i++){
            pp[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
