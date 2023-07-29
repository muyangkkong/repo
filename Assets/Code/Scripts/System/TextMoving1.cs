
using UnityEngine;
using UnityEngine.UI;
public class TextMoving1 : TutorialBase
{
    [SerializeField]
   
    public GameObject target;
  
   private bool start;
    private bool isCompleted = false;
    void Start(){
        target.SetActive(false);
    }
    
    public override void Enter()
    {
        Debug.Log("start");
        target.SetActive(true);
    }

    public override void Execute(TutorialController controller)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
             target.SetActive(false);
             isCompleted=true;
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
