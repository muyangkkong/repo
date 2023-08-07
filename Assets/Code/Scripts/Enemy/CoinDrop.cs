using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinDrop : MonoBehaviour
{
    public int enemycoin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null){
            
        }
        else{
            Text texttotalcoin=GameObject.Find("textcoin").GetComponent<Text>();
            string b=texttotalcoin.text;
            texttotalcoin.text=(int.Parse(b)+enemycoin).ToString();
        }
    }
}
