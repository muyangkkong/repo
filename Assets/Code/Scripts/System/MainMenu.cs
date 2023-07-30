using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // 배경 음악을 재생할 AudioSource 컴포넌트
    public AudioSource backgroundMusic;

    void Start()
    {
        // 배경 음악을 재생합니다.
        backgroundMusic.Play();
    }
  
    public void OnClickNewGame()
    {
        Loading.LoadScene("Tutorial");
    }

    public void OnclickOptions(){

    }

    public void OnClickQuit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}