using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicObject : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip soundClip;
    private AudioSource audioSource;
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
    private void OnTriggerEnter(Collider other)
    {

       
        // 충돌한 객체가 플레이어인지 확인
        if (other.CompareTag("Player"))
        {
            // 소리 재생
            audioSource.Play();
        }
    }
}
