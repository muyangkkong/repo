using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86.Avx;

public class GameOver : MonoBehaviour
{
    [SerializeField] public GameObject go_BaseUI; // 일시 정지 UI 패널
    GameObject targetplayer;
    CharacterHP hp;
    public static bool isOver = false;

     void Awake() {
        go_BaseUI.SetActive(false);
        targetplayer = GameObject.Find("Player");
        hp = targetplayer.GetComponent<CharacterHP>();
     }



    void Update()
    {
        if (!isOver)
        {
            if (hp.currentHp <= 0)
            {
                isOver= true;
                CallMenu();
            }
        }
    }

    private void CallMenu()
    {
    
        go_BaseUI.SetActive(true);
        Time.timeScale = 0f; // 시간의 흐름 설정. 0배속. 즉 시간을 멈춤.
    }

  

   

    public void OnClickExit()
    {
        /*
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
        */
        Time.timeScale = 1f;
        Background backgroundInstance = GameObject.FindObjectOfType<Background>();
        if (backgroundInstance != null)
            Destroy(backgroundInstance.gameObject);

        SceneManager.UnloadSceneAsync("Map");
        Destroy(MapManager.Instance.gameObject);
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}