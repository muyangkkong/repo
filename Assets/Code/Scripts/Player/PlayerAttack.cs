using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    AnimatorOverrideController animatorOverrideController;

    Instrument instrument;
    ComboData currentAttackInfo;
    
    TimingBarManager timingBarManager;

    public float maxAcceptInterval = 0.2f;

    public GameObject attackObject;

    public float power;

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
        BaseAttack();

        Ultimate();

    }

    void BaseAttack() {
        int attackInput = (Input.GetKeyDown(KeyCode.Z) ? 1 : 0) + (Input.GetKeyDown(KeyCode.X) ? 2 : 0);

        if(!CheckValidInput(attackInput)) return;
        if(timingBarManager.gameObject.activeSelf == false) return;
        if(timingBarManager.GetTimerState() == false) {
            instrument.InitProgress();
        }

        currentAttackInfo = instrument.GetCurrentAttackData();

        int timeIndex = getTimeIndex();
        float timeInterval = getTimeInterval();
        if(timeInterval > maxAcceptInterval || !CheckValidIndex(timeIndex, attackInput-1)) {
            StartCoroutine(MissAttack());
            return;
        }
        
        instrument.AttackProgress(timeIndex, attackInput-1);
        currentAttackInfo = instrument.GetCurrentAttackData();
        timingBarManager.SetAttackInfo(currentAttackInfo.children);

        OverrideAnimator();
        animator.SetTrigger("Attack");

        timingBarManager.TimerStart();
        
        float yieldGuage = YieldUltimateGuage(timeInterval);
        StartCoroutine(currentAttackInfo.attack.Attack(transform.position, GetComponent<PlayerMovement>().direction, power, yieldGuage));
    }

    void Ultimate() {

    }

    bool CheckValidInput(int attackInput) {
        if(attackInput <= 0 || attackInput >= 3) return false;
        if(!animator.GetCurrentAnimatorStateInfo(0).IsTag("Attackable")) return false;

        return true;
    }

    void OverrideAnimator() {
        animatorOverrideController["Attack"] = instrument.animationClips[currentAttackInfo.animationClipIdx];
        animator.runtimeAnimatorController = animatorOverrideController;
    }

    int getTimeIndex() {
        float time = timingBarManager.GetTimerValue();
        int timeIndex = (int)(time+0.5);
        return timeIndex;
    }

    float getTimeInterval() {
        float time = timingBarManager.GetTimerValue();
        float timeInterval = Mathf.Abs((int)(time+0.5) - time);
        return timeInterval;
    }

    bool CheckValidIndex(int timeIndex, int attackType) {
        if(timeIndex < 0 || timeIndex > 4) return false;
        if(currentAttackInfo.children[timeIndex,attackType] == 0) return false;

        return true;
    }

    IEnumerator MissAttack() {
        timingBarManager.TimerReset();
        instrument.InitProgress();
        timingBarManager.SetAttackInfo(instrument.GetCurrentAttackData().children);
        timingBarManager.SetIndicator();
        timingBarManager.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        timingBarManager.gameObject.SetActive(true);
    }

    float YieldUltimateGuage(float timeInterval) {
        float normalizedInterval = timeInterval / maxAcceptInterval;
        float steppedInterval = ((int)(normalizedInterval * 10)) / 10f;
        float score = Mathf.Cos(steppedInterval * (Mathf.PI/3));
        return score * instrument.GetGuageMultiplier();
    }
}
