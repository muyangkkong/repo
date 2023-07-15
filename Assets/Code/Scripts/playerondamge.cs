using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerondamge : MonoBehaviour
{
    public float PlayerMaxHP;
    public float PlayerCurHp;
    MeshRenderer[] meshs;

    void Awake() 
    {
        meshs = GetComponentsInChildren<MeshRenderer>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyBullet")
        {
            Bullet enemyBullet = other.GetComponent<Bullet>();
            PlayerCurHp -= enemyBullet.damage;
            StartCoroutine(OnDamge());
        }
    }

    IEnumerator OnDamge()
    {
        foreach(MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.red;
        }
        
        yield return new WaitForSeconds(1f);

        foreach(MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.red;
        }

    }
}

