
using UnityEngine;
using UnityEngine.UI;
public class TextMoving1 : TutorialBase
{
    [SerializeField]
    public GameObject groupobject;
    

    Button myButton;
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
        if (Input.GetButtonDown("Piano"))
        {
            groupobject.SetActive(false);
            
            isCompleted= true;
        }
        else if (Input.GetButtonDown("Violin"))
        {
            groupobject.SetActive(false);
            
            isCompleted= true;
        }
        else if (Input.GetButtonDown("Trumpet"))
        {
            groupobject.SetActive(false);
            
            isCompleted= true;
        }
        else if (Input.GetButtonDown("Harp"))
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
