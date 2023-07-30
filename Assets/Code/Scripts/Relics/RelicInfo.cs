using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicInfo : MonoBehaviour
{

    [SerializeField] GameObject Image;
    [SerializeField] GameObject Infotext;
    [SerializeField] GameObject Costtext;


    // Start is called before the first frame update
    void Awake(){
        Image.SetActive(false);
    }

    public void ShowInfo(string Info, int cost) {
        Infotext.GetComponent<Text>().text = Info;
        Costtext.GetComponent<Text>().text = cost + "$";
        Image.SetActive(true);

    }


    public void CloseInfo(){
        Image.SetActive(false);
    }
}
