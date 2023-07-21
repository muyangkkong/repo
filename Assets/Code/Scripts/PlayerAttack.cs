using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    AnimatorOverrideController animatorOverrideController;

    Instrument instrument;
    AttackData currentAttackInfo;
    
    TimingBarManager timingBarManager;

    void Start()
    {
        instrument = GetComponent<PlayerEquipment>().instrument;
        instrument.Construct();
        instrument.Init();
        timingBarManager = GameObject.Find("Timing Bar").GetComponent<TimingBarManager>();

        animator = GetComponent<Animator>();

        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
    }

    void Update()
    {
        int attackInput = (Input.GetKey(KeyCode.Z) ? 1 : 0) + (Input.GetKey(KeyCode.X) ? 2 : 0);

        if(attackInput <= 0 || attackInput >= 3) return;

        if(timingBarManager.GetTimerState() == false) {
            instrument.InitProgress();
        }

        currentAttackInfo = instrument.GetCurrentAttackData();

        float time = timingBarManager.GetTimerValue();
        int timeIndex = (int)(time+0.5);
        if(Mathf.Abs((int)(time+0.5) - time) > 0.2) timeIndex = -1;

        if(timeIndex < 0 || timeIndex > 4) return;
        if(currentAttackInfo.children[timeIndex,attackInput-1] == 0) return;
        
        instrument.Attack(timeIndex, attackInput-1);
        currentAttackInfo = instrument.GetCurrentAttackData();
        animatorOverrideController["Attack"] = instrument.animationClips[currentAttackInfo.animationClipIdx];
        animator.runtimeAnimatorController = animatorOverrideController;

        Debug.Log(currentAttackInfo.currentComboName);
        timingBarManager.SetAttackInfo(currentAttackInfo.children);

        animator.SetTrigger("Attack");
        timingBarManager.TimerStart();
    }
}
