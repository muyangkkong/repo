using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicObject : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip soundClip;
    private AudioSource audioSource;
    int flag = 0;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.volume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void OnTriggerEnter(Collider other)
    {

       
        // �浹�� ��ü�� �÷��̾����� Ȯ��
        if (other.gameObject.tag == "Player")
        {
            // �Ҹ� ���
            audioSource.volume = 0.5f;
            audioSource.Play();
            
           
        }
    }
   
}
