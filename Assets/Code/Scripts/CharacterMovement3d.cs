using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement3d : MonoBehaviour
{
    Rigidbody characterRigidbody;
    Animator animator;

    bool onGround = false;
    bool jumpFlag = false;
    bool fallFlag = false;
    int direction = -1;
    public float speed = 5f;

    void Start(){
        animator = GetComponent<Animator>();
        characterRigidbody = GetComponent<Rigidbody>();
    }

    void Update(){
        ProcessRunning();
        ProcessJumpAndFall();
        AnimateRunning();
        AnimateJumpAndFall();
    }
    void ProcessRunning() {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 velocity = characterRigidbody.velocity;
        velocity.x = inputX * speed;

        characterRigidbody.velocity = velocity;

        if(inputX > 0) direction = 1;
        else if(inputX < 0) direction = -1;
    }

    void ProcessJumpAndFall() {
        Vector3 velocity = characterRigidbody.velocity;
        float inputY = Input.GetAxis("Vertical");
        if(onGround && inputY > 0) {
            velocity.y = speed * 2;
            onGround = false;
            jumpFlag = true;
        }
        characterRigidbody.velocity = velocity;
    }

    void AnimateRunning() {
        Vector3 rotation = new Vector3(0, 0, 0);
        rotation.y = -direction * 90 + 180;
        characterRigidbody.rotation = Quaternion.Euler(rotation);

        Vector3 velocity = characterRigidbody.velocity;

        if (velocity.x != 0 && onGround)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void AnimateJumpAndFall() {
        if(jumpFlag) {
            Debug.Log("jump");
            jumpFlag = false;
            animator.SetTrigger("Jump");
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == 9) {
            onGround = true;
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Falling Idle")) {
                animator.SetTrigger("Landing");
            }
        }
    }
}
