using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloadscript : MonoBehaviour
{
    public string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }//나오는 횟수마다 n을 늘려서 그 int로 build하면 될거 같은데...??
    //따로 횟수 적는 칸을 적어야하나..

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(){
        MapManager.Instance.DestroyMap();
        SceneManager.LoadScene(nextSceneName);
    }
}
