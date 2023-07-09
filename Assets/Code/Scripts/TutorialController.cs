
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    [SerializeField]
    private List<TutorialBase> tutorials;
    [SerializeField]
    private string nextSceneName="";
    private TutorialBase currentTutorial=null;
    private int currentIndex=-1;
    // Start is called before the first frame update
    private void Start()
    {
        SetNextTutorial();
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentTutorial !=null)
        {
            currentTutorial.Execute(this);
        }
    }
    public void SetNextTutorial()
    {
        if (currentTutorial!=null)
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
        currentTutorial=tutorials[currentIndex];
        //새로 바뀐 튜토리얼의 Enter() 메소드 호출
        currentTutorial.Enter();

    }

    public void CompletedAllTutorials()
    {
        currentTutorial=null;

        Debug.Log("Complete All");

        if (!nextSceneName.Equals(""))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
