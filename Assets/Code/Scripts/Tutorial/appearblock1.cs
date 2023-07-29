using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appearblock1 : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
       GameObject sound=Instantiate(target,new Vector3(3,-2,0),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
