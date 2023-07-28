using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHP : MonoBehaviour
{
    PlayerStat playerstat;
    public float maxHp;
    float currentHp;

    public Slider slider;
    float currentTime;
    
    public void getDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp > 0)
            slider.value = currentHp;
        else
        {
            slider.value = maxHp;
            currentHp = maxHp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        slider.maxValue = maxHp;
        slider.value = maxHp;
        currentTime = 0;
    }
}