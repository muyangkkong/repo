using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public enum Type {SHORT, RUSH , LONG, ELITE};
    public Type enemyType;
    public int maxHealth;
    public int curHealth;
    public Transform target;
    public bool isChase;
    public BoxCollider meleeArea;
    public bool isAttack;
    public GameObject bullet;
    public GameObject[] instruments;
    

    Rigidbody rigid;
    BoxCollider Boxcollider;
    MeshRenderer[] meshs;
    NavMeshAgent nav;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        Boxcollider = GetComponent<BoxCollider>();
        meshs = GetComponentsInChildren<MeshRenderer>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        // Invoke("ChaseStart", 2);
    }
    
    void Start() 
    {
        InvokeRepeating("UpdateTarget", 0f, 0.15f);
    }

    void UpdateTarget()
    {
        Collider[]cols = Physics.OverlapSphere(transform.position, 10f, 1<< 8);

        if(cols.Length > 0)
        {
            for(int i = 0; i< cols.Length; i++)
            {
                if(cols[i].tag == "Player")
                {
                    target = cols[i].gameObject.transform;
                    Invoke("ChaseStart", 1);
                }
            }
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

    }

    void ChaseStart()
    {
        isChase = true;
        anim.SetBool("isWalk", true);

    }

    void Update()
    {
        if(nav.enabled)
       {
            nav.SetDestination(target.position);
            nav.isStopped = !isChase;
       }    //자동추적
        
    } 
    

    void FreezeVelocity() 
    {
       if(isChase)
        {
           rigid.velocity = Vector3.zero;
           rigid.angularVelocity = Vector3.zero;
        }
    } 
    


    void Targeting()
    {
        float targetRadius = 0;
        float targetRange = 0;

        switch(enemyType)
        {
            case Type.SHORT:
                targetRadius = 0.5f;
                targetRange = 1.5f;
                break;
            case Type.RUSH:
                targetRadius = 0.5f;
                targetRange = 7f;
                break;
            case Type.LONG:
                targetRadius = 0.5f;
                targetRange = 12f;
                break;
            case Type.ELITE:
                targetRadius = 1f;
                targetRange = 5f;
                break;
        }

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position,targetRadius ,transform.forward, targetRange, LayerMask.GetMask("Player"));
            
        if(rayHits.Length > 0 && !isAttack)
        {
            StartCoroutine(Attack());
        }
    }

  
    IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        anim.SetBool("isAttack", true);
         
         switch(enemyType)
        {
            case Type.SHORT: // 근거리
                yield return new WaitForSeconds(0.01f); 
                anim.SetBool("isAttack", true);
                meleeArea.enabled = true;  

                yield return new WaitForSeconds(1.2f);
                meleeArea.enabled = false;  

                anim.SetBool("isAttack", false);
                anim.SetBool("isWalk", false);  
                
                nav.isStopped = !isChase;
                yield return new WaitForSeconds(2f); 
                break;


            case Type.RUSH:   //돌진
                yield return new WaitForSeconds(0.01f);
                rigid.AddForce(transform.right * 10, ForceMode.Impulse);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.5f); 
                rigid.velocity =Vector3.zero;
                meleeArea.enabled = false;  


                
                 nav.enabled = false;
                if(nav.enabled)
                {
                    nav.SetDestination(target.position);
                    nav.isStopped = !isChase;
                }   
                yield return new WaitForSeconds(3f); 
                nav.enabled = true;
                break;

            
            case Type.LONG:    //원거리
                yield return new WaitForSeconds(0.5f); 
                anim.SetBool("isAttack", true);
                GameObject instantBullet = Instantiate(bullet, transform.position, transform.rotation);
                Rigidbody rigidBullet = instantBullet.GetComponent<Rigidbody>();
                rigidBullet.velocity = transform.forward * 20;

                anim.SetBool("isAttack", false);
                anim.SetBool("isWalk", false);
               
                yield return new WaitForSeconds(2f); 
                
                break;  
                
            case Type.ELITE:
                yield return new WaitForSeconds(0.1f);
                rigid.AddForce(transform.forward * 10, ForceMode.Impulse);
                anim.SetBool("isAttack", true);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(1f); 
                rigid.velocity =Vector3.zero;
                anim.SetBool("isAttack", false);
                meleeArea.enabled = false;  


                yield return new WaitForSeconds(0.1f); 
                anim.SetBool("isAttack", true);
                meleeArea.enabled = true;  

                yield return new WaitForSeconds(1.5f);
                anim.SetBool("isAttack", false);
                meleeArea.enabled = false;  
                anim.SetBool("isWalk", false);

                nav.enabled = false;
                if(nav.enabled)
                {
                    nav.SetDestination(target.position);
                    nav.isStopped = !isChase;
                }   
                yield return new WaitForSeconds(3f); 
                nav.enabled = true;
                break;
        }


        isChase = true;
        isAttack = false;
       
    }
    
    void FixedUpdate()
    {
        Targeting();
        FreezeVelocity();
    }
    



    void OnTriggerEnter(Collider other)    //피격
    {
        if(other.tag == "Instrument") 
        {
            //Instrument instrument = other.GetComponent<Instrument>();//
            //curHealth -= instrument.AttackDamage;//
            curHealth -= 1;
            Vector3 reactVec = transform.position - other.transform.position;
            StartCoroutine(OnDamge(reactVec));  //넉백
            Debug.Log("   :" +curHealth);   //피격 로그확인용
        }  
        else if(other.tag == "1")
        {

        }
    }

    


    IEnumerator OnDamge(Vector3 reactVec)
    {
        foreach(MeshRenderer mesh in meshs)
            mesh.material.color = Color.red;

        
        yield return new WaitForSeconds(0.1f);

        if(curHealth > 0)
        {
            foreach(MeshRenderer mesh in meshs)
                mesh.material.color = Color.black;   //색깔 원위치
        }
        else
        {
            foreach(MeshRenderer mesh in meshs)
                mesh.material.color = Color.white;
            gameObject.layer = 11;   //enemydead layer  
            isChase = false;
            nav.enabled = false;
            anim.SetTrigger("doDie");


            reactVec = reactVec.normalized;
            reactVec += Vector3.up;
            rigid.AddForce(reactVec * 5, ForceMode.Impulse);    // 죽음 후 넉백
            
            Destroy(gameObject, 2); 

        }
    }
}

