using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;
    
    
    GameObject noteObject;// 변경할 새로운 머티리얼을 참조하는 변수

    private void Start()
    {
        
        noteObject = gameObject;
    }

    public void HideNote()
    {
        noteObject.SetActive(false);
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.localPosition+=Vector3.right * noteSpeed * Time.deltaTime;
    }
}
