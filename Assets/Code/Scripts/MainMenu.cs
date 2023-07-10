using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
    public void OnClickNewGame()
    {
        SceneManager.LoadScene("Loading");
    }

    public void OnclickOptions(){

    }

    public void OnClickQuit()
    {
        #if UNITY_EDITOR //에디터에서는 
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
