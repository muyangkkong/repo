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

    public AudioClip walkingSound1;
    public AudioClip walkingSound2;
    private AudioSource audioSource;
    private bool isWalking = false;

     private int currentWalkingSoundIndex = 0;

    void Start(){
        animator = GetComponent<Animator>();
        characterRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
        float inputX = Input.GetAxisRaw("Horizontal");

        if(movable > 0) inputX = 0;

        Vector3 velocity = characterRigidbody.velocity;
        velocity.x = inputX * speed;
        characterRigidbody.velocity = velocity;
        
        if(inputX != 0) direction = (int)inputX;
        Vector3 rotation = new Vector3(0, 0, 0);
        rotation.y = -direction * 90 + 180;
        characterRigidbody.rotation = Quaternion.Euler(rotation);

        if (onGround && inputX != 0)
    {
        animator.SetBool("Run", true);
        if (!isWalking)
        {
            isWalking = true;
            PlayFootstepSound();
        }
    }
    else
    {
        animator.SetBool("Run", false);
        if (isWalking)
        {
            isWalking = false;
            CancelInvoke("PlayFootstepSound");
        }
    }
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

    void PlayFootstepSound()
{
    if (!audioSource.isPlaying)
    {
        if (currentWalkingSoundIndex == 0)
        {
            audioSource.PlayOneShot(walkingSound1);
            currentWalkingSoundIndex = 1;
        }
        else
        {
            audioSource.PlayOneShot(walkingSound2);
            currentWalkingSoundIndex = 0;
        }
    }

    // 발자국 소리 사이에 겹치지 않도록 딜레이를 설정합니다.
    float footstepDelay = 0.2f; // 필요에 따라 이 값을 조정하세요
    Invoke("PlayFootstepSound", footstepDelay);
}
}
