using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] walk;
    public AudioClip[] ui;
    public AudioClip[] battle;
    public AudioClip[] attack;

    public AudioSource audioSource;

    private static AudioManager instance = null;

     void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
   
            Destroy(this.gameObject);
        }
    }

    public static AudioManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    
    
    void Start()
    {
         audioSource = GetComponent<AudioSource>();
    }

    public void PlayWalkAudio(int index)
    {
        if (index >= 0 && index < walk.Length)
        {
            audioSource.PlayOneShot(walk[index]);
        }
        else
        {
            Debug.LogWarning("Invalid Walk sound index!");
        }
    }

    public void PlayUIAudio(int index)
    {
        if (index >= 0 && index < ui.Length)
        {
            audioSource.PlayOneShot(ui[index]);
        }
        else
        {
            Debug.LogWarning("Invalid UI sound index!");
        }
    }

    public void PlayBattleAudio(int index)
    {
        if (index >= 0 && index < battle.Length)
        {
            audioSource.PlayOneShot(battle[index]);
        }
        else
        {
            Debug.LogWarning("Invalid Battle sound index!");
        }
    }

    public void PlayAttackAudio(int index)
    {
        if (index >= 0 && index < attack.Length)
        {
            audioSource.PlayOneShot(attack[index]);
        }
        else
        {
            Debug.LogWarning("Invalid Attack sound index!");
        }
    }
}
