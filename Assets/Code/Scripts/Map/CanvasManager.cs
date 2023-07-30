using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class CanvasManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] uiObject; // Ȱ��ȭ �Ǵ� ��Ȱ��ȭ�� UI ������Ʈ
    GameObject targetplayer;
    PlayerMovement move;
     void Awake()
    {
        targetplayer = GameObject.Find("Player");
        move = targetplayer.GetComponent<PlayerMovement>();
    }
    // UI�� Ȱ��ȭ�ϴ� �Լ�

    IEnumerator ActivateAndDeactivateUI()
    {
       
        yield return new WaitForSeconds(0.3f); //
        uiObject[1].SetActive(false);
        uiObject[0].SetActive(true);
        yield return new WaitForSeconds(0.4f);
        uiObject[0].SetActive(false);
        uiObject[1].SetActive(false);
        uiObject[2].SetActive(true);
        uiObject[3].SetActive(true);
        uiObject[4].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        move.speed = 10.0f;

    }

    // �ڷ�ƾ ������ �����ϴ� �Լ�
  




    void Start()
    {
        uiObject[0].SetActive(false);
        uiObject[1].SetActive(false);
        uiObject[2].SetActive(true);
        uiObject[3].SetActive(true);
        uiObject[4].SetActive(true);
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
        uiObject[4].SetActive(false);
        move.speed = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
