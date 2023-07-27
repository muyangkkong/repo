using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class CanvasManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] uiObject; // 활성화 또는 비활성화할 UI 오브젝트

    // UI를 활성화하는 함수

    IEnumerator ActivateAndDeactivateUI()
    {
       
        yield return new WaitForSeconds(0.00000025f); //
        uiObject[1].SetActive(false);
        uiObject[0].SetActive(true);
        yield return new WaitForSeconds(0.0000005f);
        uiObject[0].SetActive(false);
        uiObject[1].SetActive(false);
        uiObject[2].SetActive(true);
        uiObject[3].SetActive(true);
    }

    // 코루틴 실행을 시작하는 함수
  




    void Start()
    {
        uiObject[0].SetActive(false);
        uiObject[1].SetActive(false);
        uiObject[2].SetActive(true);
        uiObject[3].SetActive(true);
    }
    public void Activate()
    {
        StartCoroutine(ActivateAndDeactivateUI());

    }
    public void Setting()
    {
        uiObject[1].SetActive(true);
        uiObject[0].SetActive(false);
        uiObject[2].SetActive(false);
        uiObject[3].SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
