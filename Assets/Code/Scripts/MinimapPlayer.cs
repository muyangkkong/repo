using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPlayer : MonoBehaviour
{
    Rigidbody2D characterRigidbody;
    bool onGround = false;
    bool movable = true;
    int direction = 1;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        Fall();
        
    }
    void Run()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        Vector3 velocity = characterRigidbody.velocity;
        velocity.x = inputX * speed;
        characterRigidbody.velocity = velocity;
    }
    void Jump()
    {
        Vector3 velocity = characterRigidbody.velocity;
        float inputY = Input.GetAxisRaw("Vertical");
        
        
            
        
            if(onGround && inputY == 1)
            {
               velocity.y = speed * 1.5f;
               onGround = false;
            }
            characterRigidbody.velocity = velocity;
            Debug.Log(inputY);
        
        
        
        
    }
    void Fall() 
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position - Vector3.down * 0.1f, Vector3.down, out hit, 1f, LayerMask.GetMask("Platform"))) {
            Debug.DrawRay(transform.position - Vector3.down * 0.1f, Vector3.down * hit.distance, Color.red);
        }
        else {
            
            onGround = false;
            Debug.DrawRay(transform.position - Vector3.down * 0.1f, Vector3.down * 0.20f, Color.blue);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 9) {
            onGround = true;
            
        }
    }
    private void OnCollisionEnter(Collision other) {

    }
        
    
}
