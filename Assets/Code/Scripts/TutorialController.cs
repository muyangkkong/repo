using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<TutorialBase> turotials;
    [SerializeField]
    private string nextSceneName="";

    private TutorialBase currentTutorial= null;
    private int currentIndex =-1;

    void Start()
    {
        SetNextTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTutorial != null)
        {
            currentTutorial.Execuge(this);
        }
    }

    public void SetNExtTutorial()
    {
        //현재 튜토리얼의 Exit() 메소드 호출
        if (currentTutorial != null)
        {
            currentTutorial.Exit();
        }
        if (currentIndex >= tutorials.Count-1)
        {
            CompletedAllTutorials();
            return;
        }
        //다음 튜토리얼 과정을 currentTutorial로 등록 
        currentIndex++;
        currnetTutorial = tutorials[currentIndex];
        //새로 바뀐 튜토리얼의 Enter() 메소드 호출  
        currentTutorial.Enter();
    } 
}
