using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public bool ismelee;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject,3);
        }
     
    }

    void OnTriggerEnter(Collider other) 
    {
       if(!ismelee && other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if(!ismelee && other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
