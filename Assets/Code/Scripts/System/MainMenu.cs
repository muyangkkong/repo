using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
    public void OnClickNewGame()
    {
        Loading.LoadScene("3dScene");
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
