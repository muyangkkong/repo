using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody characterRigidbody;
    Animator animator;

    bool onGround = false;
    public int movable = 0;
    public int direction = 1;
    public float speed = 5f;

    void Start(){
        animator = GetComponent<Animator>();
        characterRigidbody = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate(){
        Run();
        Jump();
        Fall();
        if(onGround && Physics.Raycast(transform.position, Vector3.down, 0.05f, LayerMask.GetMask("Platform"))) {
            Vector3 velocity = characterRigidbody.velocity;
            velocity.y = 0;
            characterRigidbody.velocity = velocity;
        }
    }
    
    void Run() {
        if(movable > 0) return;

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
            animator.ResetTrigger("Land");
        }
        characterRigidbody.velocity = velocity;
    }

    void Fall() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position - Vector3.down * 0.5f, Vector3.down, out hit, 1.0f, LayerMask.GetMask("Platform"))) {
            Debug.DrawRay(transform.position - Vector3.down * 0.5f, Vector3.down * hit.distance, Color.red);
        }
        else {
            animator.SetBool("Fall", true);
            onGround = false;
            Debug.DrawRay(transform.position - Vector3.down * 0.5f, Vector3.down * 1.0f, Color.blue);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Platform")) {
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
