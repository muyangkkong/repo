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
    public Slider slider; // ui hp ������
    float currentTime; // �꿴�� �� ������ �ٴ� �ӵ� ����
    
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
            currentTime = 0;// ���� �ð� �ʱ�ȭ
            getDamage(1.0f);
        }
    }
    void OnCollisionStay(Collision other) // ��� ���� ��
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
