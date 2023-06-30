using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
        public GameObject attackArea;
        public GameObject instrumentObject;

        Instrument instrument;

        AttackData attackdata;

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

    }
}
