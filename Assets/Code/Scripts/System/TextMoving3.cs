
using UnityEngine;
using UnityEngine.UI;
public class TextMoving3 : TutorialBase
{
    [SerializeField]
    public GameObject groupobject;
    public GameObject block;
    public GameObject explain;

     
    private bool isCompleted = false;
    
    void Start()
    {
        groupobject.SetActive(false);
        block.SetActive(false);
    }
    public override void Enter()
    {
        groupobject.SetActive(true);
        block.SetActive(true);
  
    }

    public override void Execute(TutorialController controller)
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            groupobject.SetActive(false);
            block.SetActive(false);
            explain.SetActive(false);
      
            isCompleted= true;
        }
        if (isCompleted==true)
        {
            controller.SetNextTutorial();
        }
    
    }

    // Update is called once per frame
    public override void Exit()
    {
        
    }
}
