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
    
  
    private bool secondenter= false;
    private bool isCompleted = false;
    void Start(){
        groupobject.SetActive(false);
        target.SetActive(false);
        letter.SetActive(false);
        

    }
    
    public override void Enter()
    {
       
       
        groupobject.SetActive(true);
        letter.SetActive(true);
    }

    public override void Execute(TutorialController controller)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
             if (!secondenter){
                firstenter();
                secondenter=true;
             }
             else{
                  second_enter();
                  isCompleted=true;
             }
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

    void firstenter(){
       
        target.SetActive(true);
        letter.SetActive(false);

    }
    void second_enter(){
          groupobject.SetActive(false);
          letter.SetActive(false);
          target.SetActive(false);

    }
    
}
