using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBase : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void Enter();
// 해당 튜토리얼 과정을 시작할때 1회 호출
    public abstract void Execute(TutorialController controller);
// 해당 튜토리얼 과정을 진행하는 동안 매 프레임 호출
    public abstract void Exit();
    // 해당 튜토리얼 과정을 종료할 떄 1회 호출
    
}
