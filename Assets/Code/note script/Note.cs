using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;
    public Material newMaterial; // 변경할 새로운 머티리얼을 참조하는 변수

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>(); // 해당 오브젝트의 Renderer 컴포넌트를 가져옴
        renderer.material = newMaterial;
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.localPosition+=Vector3.right * noteSpeed * Time.deltaTime;
    }
}
