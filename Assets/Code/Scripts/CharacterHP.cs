using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHP : MonoBehaviour
{
    public float HP;
    /*{
        get { return (HP); }    
        set { HP = value; } 
    }*/
    public Slider slider; // ui hp 게이지
    float currentTime; // 닿였을 때 데미지 다는 속도 조절
    
    void getDamage(float damage)
    {
        HP -= damage;
        if (HP > 0)
            slider.value = 225*(HP/100);
        else
        {
            slider.value = 100;
            HP = 100f;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        HP = 100f;
        slider.value = HP;
        currentTime = 0;
    }

     void Update()
    {

        


    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentTime = 0;// 누적 시간 초기화
            getDamage(1.0f);
        }
    }
    void OnCollisionStay(Collision other) // 계속 닿을 시
    {
       
        if (other.gameObject.tag == "Enemy")
        {
            currentTime+= Time.deltaTime;
            if (currentTime > 1)
            {
                currentTime = 0;
                getDamage(1.0f);
            }     
            }

    }

    
}
