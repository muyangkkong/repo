using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.localPosition+=Vector3.right * noteSpeed * Time.deltaTime;
    }
}
