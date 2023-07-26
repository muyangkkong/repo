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

       
        // 충돌한 객체가 플레이어인지 확인
        if (other.gameObject.tag == "Player")
        {
            // 소리 재생
            audioSource.Play();
            
           
        }
    }
   
}
