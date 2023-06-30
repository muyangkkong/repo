using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPinfo : MonoBehaviour
{
    GameObject target;
    CharacterHP PlayerHP;
    RectTransform RTransform;
    Vector2 currentSize;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        PlayerHP = target.GetComponent<CharacterHP>();
        RTransform = GetComponent<RectTransform>();
        currentSize = RTransform.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        
        currentSize.x = (currentSize.x - (225 * ((100-PlayerHP.HP) / 100)));
        RTransform.sizeDelta = currentSize;
        Debug.Log("³Êºñ: "+ currentSize.x);
    }
}
