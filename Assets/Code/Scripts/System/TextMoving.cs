
using UnityEngine;
using UnityEngine.UI;
public class TextMoving : TutorialBase
{
    [SerializeField]
    public GameObject groupobject;
    

     
    private bool isCompleted = false;
    
    void Start()
    {
        groupobject.SetActive(false);
    }
    public override void Enter()
    {
        groupobject.SetActive(true);
  
    }

    public override void Execute(TutorialController controller)
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            groupobject.SetActive(false);
      
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
