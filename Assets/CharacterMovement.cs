using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    TimingBarManager timingBarManager;

    bool isGround;
    bool movable = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        timingBarManager = GameObject.Find("Timing Bar").GetComponent<TimingBarManager>();
        isGround = false;
    }

    void Update()
    {
        AnimateRunning();
        AnimateJumping();
        AnimateAttack();
        if(Input.GetKey(KeyCode.T)) {
            timingBarManager.TimerStart();
        }
    }

    void AnimateRunning() {
        int direction = (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0) + (Input.GetKey(KeyCode.RightArrow) ? 1 : 0);

        if (movable && direction != 0)
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = (direction == -1);
            if (direction == -1)
            {
                this.transform.Translate(-2f * Time.deltaTime, 0, 0);
            }
            if (direction == 1)
            {
                this.transform.Translate(2f * Time.deltaTime, 0, 0);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void AnimateJumping() {
        
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
        
        if(rigid.velocity.y <= 0) {
            animator.SetBool("isFalling", true);
            if(rayHit.collider != null) {
                if(rayHit.distance < 0.45) {
                    animator.SetBool("isFalling", false);
                    isGround = true;
                }
            }
        }
        animator.SetBool("isJumping", !isGround);
        if(movable && isGround && Input.GetKey(KeyCode.UpArrow) && rigid.velocity.y == 0) {
            isGround = false;
            rigid.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
        }
    }

    void AnimateAttack() {
        if((animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))) { 
            if(Input.GetKeyDown(KeyCode.Z)) {
                timingBarManager.TimerStart();
                animator.SetTrigger("AttackA");
            }
            if(Input.GetKeyDown(KeyCode.X)) {
                timingBarManager.TimerStart();
                animator.SetTrigger("AttackB");
            }
            if(Input.GetKeyDown(KeyCode.C)) {
                timingBarManager.TimerStart();
                animator.SetTrigger("AttackC");
            }
        }

        if((animator.GetCurrentAnimatorStateInfo(0).IsName("AttackA")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("AttackB")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("AttackC"))) {
            // Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.0f
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f) {
                movable = false;
            }
            else {
                movable = true;
            }
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f) {
                if(Input.GetKeyDown(KeyCode.Z)) {
                    Debug.Log("Combo A");
                    timingBarManager.TimerStart();
                    animator.SetTrigger("AttackA");
                }
                if(Input.GetKeyDown(KeyCode.X)) {
                    Debug.Log("Combo B");
                    timingBarManager.TimerStart();
                    animator.SetTrigger("AttackB");
                }
                if(Input.GetKeyDown(KeyCode.C)) {
                    Debug.Log("Combo C");
                    timingBarManager.TimerStart();
                    animator.SetTrigger("AttackC");
                }
            }
        }
        else {
            movable = true;
        }
    }
}

/*
&   아 하기 싫다~  
*/