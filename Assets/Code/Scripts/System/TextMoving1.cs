using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextMoving1 : TutorialBase
{
    [SerializeField]
   public GameObject groupobject;
    public GameObject target;
     public GameObject letter;

  
   
    private bool isCompleted = false;
    void Start(){
        groupobject.SetActive(false);
        target.SetActive(false);
        letter.SetActive(false);
        

    }
    
    public override void Enter()
    {
        TypingManager typingManager = groupobject.GetComponent<TypingManager>();

        Invoke("appear",typingManager.m_Message.Length * 0.03f);
       
        groupobject.SetActive(true);
        letter.SetActive(true);
    }

    public override void Execute(TutorialController controller)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
             groupobject.SetActive(false);
             target.SetActive(false);
             letter.SetActive(false);
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

    void appear(){
       
        target.SetActive(true);
        letter.SetActive(false);

    }
    
}
