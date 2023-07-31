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
    public float currentHp;

    Slider slider;
    float currentTime;

    public AudioSource audioSource;
    
    public void getDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp > 0)
            slider.value = currentHp;
        else
        {
            slider.value = 0;
            currentHp = 0;
        }
         if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
    public void getHeal(float damage)
    {
        if (currentHp + damage >= maxHp)
        {
            currentHp = maxHp;
        }
        else
        {
            currentHp += damage;
        }
        slider.value = currentHp;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameObject.Find("HpInfo"));
        slider = GameObject.Find("HpInfo").GetComponent<Slider>();
        currentHp = maxHp;
        slider.maxValue = maxHp;
        slider.value = maxHp;
        currentTime = 0;
    }
}