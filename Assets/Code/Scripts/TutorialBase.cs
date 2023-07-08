using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TutorialBase : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void Enter();
    public abstract void Execute(TutorialController controller);
    public abstract void Exit();

        
    
    // Update is called once per frame
    
    
}
