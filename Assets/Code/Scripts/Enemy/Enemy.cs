using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum State {
        idle,
        wander,
        chase,
        attack
    }

    Rigidbody rigid;
    Animator animator;

    protected State currentState;

    public float chaseRangeMin = 1.5f;
    public float chaseRangeMax = 6.0f;
    public float unchaseRadius = 8.0f;
    public float speed = 2;

    [SerializeField]
    int _moveTo = 0;
    int moveTo {
        get {return _moveTo;}
        set {
            if(value != 0) direction = value;
            _moveTo = value;
        }
    }
    [SerializeField]
    protected int direction = -1;

    float currentHp;
    public float maxHp;

    protected float AttackDamage = 10.0f;

    void Awake() {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start() {
        Invoke("Wander", Random.Range(0.5f, 5f));
        currentHp = maxHp;
    }
    
    void FixedUpdate()
    {
        //Ckeck Platform
        switch(currentState) {
        case State.idle:
        case State.wander:
            if(!CheckPlatform()) moveTo *= -1;
            FindTarget();
            break;
        case State.chase:
        case State.attack:
            if(!CheckPlatform()) moveTo = 0;
            break;
        }

        //move
        Vector3 velocity = rigid.velocity;
        velocity.x = moveTo * speed;
        rigid.velocity = velocity;

        Vector3 rotation = new Vector3(0, 0, 0);
        rotation.y = -direction * 70 + 180;
        rigid.rotation = Quaternion.Euler(rotation);
    }

    bool CheckPlatform() {
        RaycastHit hit;
        return Physics.Raycast(transform.position + Vector3.right * moveTo * 0.3f, Vector3.down, out hit, 1f, LayerMask.GetMask("Platform"));
    }

    void Wander() {
        moveTo = Random.Range(-1, 2);
        
        if(moveTo == 0) animator.SetBool("Wander", false);
        else animator.SetBool("Wander", true);

        currentState = State.wander;
        Invoke("Wander", Random.Range(0.5f, 5f));
    }

    void FindTarget() {
        Collider[] colliders = Physics.OverlapCapsule(
            transform.position + Vector3.left * chaseRangeMax, 
            transform.position + Vector3.right * chaseRangeMax, 
            1f, LayerMask.GetMask("Player")
        );
        if(colliders.Length > 0) {
            Debug.Log("Player Detected");
            CancelInvoke("Wander");
            Invoke("Chase", 0f);
        }
    }
    
    void Chase() {
        animator.SetBool("Chase", true);
        animator.SetBool("Wander", false);
        currentState = State.chase;
        Collider[] colliders = Physics.OverlapSphere(transform.position, unchaseRadius, LayerMask.GetMask("Player"));
        if(colliders.Length > 0) {
            if(colliders[0].transform.position.x > transform.position.x) {
                moveTo = 1;
            }
            else {
                moveTo = -1;
            }
            if(Mathf.Abs(colliders[0].transform.position.x - transform.position.x) < 0.2f) {
                moveTo = 0;
            }
        }
        Invoke("Chase", 0.05f);

        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.right * moveTo, out hit, chaseRangeMin, LayerMask.GetMask("Player"))) {
            //Chase to Attack
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;
            animator.SetTrigger("Attack");
            CancelInvoke("Chase");
            moveTo = 0;
            StartCoroutine(Attack());
            Debug.Log("coroutine end");
        }
        if(colliders.Length == 0) {
            //Chase to Wander
            animator.SetBool("Chase", false);
            moveTo = 0;
            CancelInvoke("Chase");
            Invoke("Wander", Random.Range(0.5f, 5f));
        }
    }

    public virtual IEnumerator Attack() {
        yield return new WaitForSeconds(0.1f);
        Invoke("Chase", 0f);
    }

    public void Damage(float amount, float knockback) {
        StopAllCoroutines();
        CancelInvoke();
        moveTo = 0;

        Debug.Log("Enemy Get " + amount + " Damage!");
        currentHp -= amount;
        StartCoroutine(Knockback(knockback));
        StartCoroutine(OnDamage());
    }

    IEnumerator Knockback(float knockback) {
        float timer = 0f;
        while (timer < 1f)
        {
            float t = Mathf.Pow(timer-1, 3) + 1;
            float knockbackForceThisFrame = Mathf.Lerp(knockback, 0f, t);
            rigid.AddForce(-direction * knockbackForceThisFrame, 0, 0, ForceMode.Acceleration);
            timer += Time.fixedDeltaTime;

            yield return Time.fixedDeltaTime;
        }
    }


    public virtual IEnumerator OnDamage() {
        animator.SetTrigger("Hit");
        GetComponentInChildren<Renderer>().material.color = new Color(1f, 0.274f, 0.27f);
        yield return new WaitForSeconds(0.06f);
        GetComponentInChildren<Renderer>().material.color = Color.black;
        yield return new WaitForSeconds(0.06f);
        GetComponentInChildren<Renderer>().material.color = new Color(1f, 0.274f, 0.27f);
        yield return new WaitForSeconds(0.06f);
        GetComponentInChildren<Renderer>().material.color = Color.black;
        yield return new WaitForSeconds(0.06f);
        GetComponentInChildren<Renderer>().material.color = new Color(1f, 0.274f, 0.27f);
        yield return new WaitForSeconds(0.06f);
        GetComponentInChildren<Renderer>().material.color = Color.black;
        

        if(currentHp <= 0) {
            Invoke("Die", 0f);
        }
        else {
            yield return new WaitForSeconds(0.7f);
            Invoke("Wander", 0f);
        }
    }

    public virtual void Die() {
        animator.SetTrigger("Die");
    }
}
