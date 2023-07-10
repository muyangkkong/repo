using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody characterRigidbody;
    Animator animator;

    bool onGround = false;
    bool movable = true;
    int direction = 1;
    public float speed = 5f;

    void Start(){
        animator = GetComponent<Animator>();
        characterRigidbody = GetComponent<Rigidbody>();
    }

    void Update(){
        Run();
        Jump();
        Fall();
    }
    
    void Run() {
        if(!movable) return;

        float inputX = Input.GetAxisRaw("Horizontal");

        Vector3 velocity = characterRigidbody.velocity;
        velocity.x = inputX * speed;
        characterRigidbody.velocity = velocity;

        if(inputX != 0) direction = (int)inputX;
        Vector3 rotation = new Vector3(0, 0, 0);
        rotation.y = -direction * 90 + 180;
        characterRigidbody.rotation = Quaternion.Euler(rotation);

        if (onGround && inputX != 0) animator.SetBool("Run", true);
        else animator.SetBool("Run", false);
    }

    void Jump() {
        Vector3 velocity = characterRigidbody.velocity;
        float inputY = Input.GetAxisRaw("Vertical");
        if(onGround && inputY == 1) {
            velocity.y = speed * 1.5f;
            onGround = false;
            animator.SetTrigger("Jump");
        }
        characterRigidbody.velocity = velocity;
    }

    void Fall() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position - Vector3.down * 0.1f, Vector3.down, out hit, 0.15f, LayerMask.GetMask("Platform"))) {
            Debug.DrawRay(transform.position - Vector3.down * 0.1f, Vector3.down * hit.distance, Color.red);
        }
        else {
            animator.SetBool("Fall", true);
            onGround = false;
            Debug.DrawRay(transform.position - Vector3.down * 0.1f, Vector3.down * 0.15f, Color.blue);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 9) {
            onGround = true;
            if(animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump")) {
                animator.SetTrigger("Land");
                animator.SetBool("Fall", false);
            }
        }
    }

    private void OnCollisionEnter(Collision other) {

    }
}
