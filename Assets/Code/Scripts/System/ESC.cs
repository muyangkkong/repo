using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESC : MonoBehaviour
{
    [SerializeField] public GameObject go_BaseUI; // 일시 정지 UI 패널

    public static bool isPause;

    private void Awake() {
        go_BaseUI.SetActive(false);
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            if (isPause)
                CallMenu();
            else
                CloseMenu();
        }
    }

    private void CallMenu()
    {
        Debug.Log("Pause");
        //GmaeManager.isPause = true;
        go_BaseUI.SetActive(true);
        Time.timeScale = 0f; // 시간의 흐름 설정. 0배속. 즉 시간을 멈춤.
    }

    private void CloseMenu()
    {
        //GameManager.isPause = false;
        go_BaseUI.SetActive(false); 
        Time.timeScale = 1f; // 1배속 (정상 속도)
    }

    public void OnClickResume()
    {
        Debug.Log("이어하기");
        isPause = !isPause;
        CloseMenu();
    }

    public void OnClickMainMenu()
    {
        Debug.Log("몌인 몌뉴");
        Loading.LoadScene("Main Menu");
        
    }

    public void OnClickExit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}