
using UnityEngine;

public class TutorialFadeEffect : TutorialBase
{
    [SerializeField]
    private FadeEffect fadeEffect;
    [SerializeField]
    private bool   isFadeIn= false;
    private bool   isCompleted= false;
    // Start is called before the first frame update
    public override void Enter()
    {
        if (isFadeIn ==true )
        {
            fadeEffect.FadeIn(OnAfterFadeEffect);
        }
        else
        {
            fadeEffect.FadeOut(OnAfterFadeEffect);
        }
    }

    // Update is called once per frame
    private void OnAfterFadeEffect()
    {
        isCompleted= true;
    }

    public override void Execute(TutorialController controller)
    {
        if (isCompleted==true)
        {
            controller.SetNextTutorial();
        }
    
    }
    public override void Exit()
    {
       
    }
}
