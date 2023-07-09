using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackArea;
    public GameObject instrumentObject;

    Instrument instrument;

    AttackTree currentAttackInfo;

    TimingBarManager timingBarManager;

/*         public bool attacking = false;
        public float WaitingTime = 1.0f;
        private float TimeToWait = 0f;

        public float AttackingTime = 0.2f;
        public float TimeAttacking = 0f;
        
        public float timer = 0;

        public float PlayerDamage;
        public string PlayerAttackAnimation; */

    void Start()
    {
        attackArea.SetActive(false);
        instrument = instrumentObject.GetComponent<Instrument>();
        instrument.Construct();
        instrument.Init();
        timingBarManager = GameObject.Find("Timing Bar").GetComponent<TimingBarManager>();
    }

    void Update()
    {
        /* if (attacking)
        {
            timer+=Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Z) && TimeToWait <= 0)
        {   
            attacking = true;
            attackdata = instrument.GetComponent<Instrument>().AttackA();
            if (attackdata!=null)
            {
                TimeToWait = WaitingTime;
            }
            else 
            {
                attackArea.SetActive(true);
                TimeAttacking = AttackingTime;
                PlayerDamage = attackdata.damage;
                PlayerAttackAnimation = attackdata.animationTrigger;

            }
            
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (attacking)
            {
                timer+=Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.X) && TimeToWait <= 0)
            {   
                attacking = true;
                attackdata = instrument.GetComponent<Instrument>().AttackB();
                if (attackdata!=null)
                {
                    TimeToWait = WaitingTime;
                }
                else 
                {
                    attackArea.SetActive(true);
                    TimeAttacking = AttackingTime;
                    PlayerDamage = attackdata.damage;
                    PlayerAttackAnimation = attackdata.animationTrigger;
                }
            }
        }
        
        if (WaitingTime > 0) {WaitingTime-=Time.deltaTime;}
        if (TimeAttacking > 0) {TimeAttacking-=Time.deltaTime;}
        else {attackArea.SetActive(false);} */

        int attackInput = (Input.GetKey(KeyCode.Z) ? 1 : 0) + (Input.GetKey(KeyCode.X) ? 2 : 0);
        if(attackInput > 0) {
            if(timingBarManager.GetTimerState() == false) {
                instrument.InitProgress();
            }
            currentAttackInfo = instrument.GetCurrentAttackProgress();
            float time = timingBarManager.GetTimerValue();
            int timeIndex = (int)(time+0.5);
            if(Mathf.Abs((int)(time+0.5) - time) > 0.2) timeIndex = -1;

            if(timeIndex == -1) return;
            if(attackInput == 3) return;
            if(currentAttackInfo.Children[timeIndex,attackInput-1] == null) return;

            instrument.Attack(timeIndex, attackInput-1);
            currentAttackInfo = instrument.GetCurrentAttackProgress();
            timingBarManager.SetAttackTree(currentAttackInfo);
            timingBarManager.TimerStart();
        }
    }
}
