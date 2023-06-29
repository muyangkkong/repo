using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // Start is called before the first frame update
    timemanager theTimingManager;
    void Start()
    {
        theTimingManager=FindObjectOfType<timemanager>();
    }

    // Update is called once per fram
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            theTimingManager.CheckingTiming();

        }
    }
}
