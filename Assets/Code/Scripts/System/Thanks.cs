using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thanks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickMainMenu()
    {

        SceneManager.UnloadSceneAsync("Thanks");
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        
    }
}
