using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected MeshRenderer meshRenderer;
    Rigidbody rigid;

    protected bool isShot = false;
    protected Vector3 direction;
    protected float damage;
    public Color color;
    public float speed;
    public float duration;
    float currentTime;

    Transform childTransform;

    void Awake() {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        rigid = GetComponent<Rigidbody>();
        childTransform = transform.GetChild(0).transform;
    }

    void Start() {
        meshRenderer.material.color = color;
    }

    void FixedUpdate() {
        if(isShot) {
            rigid.velocity = direction * speed;
            childTransform.Rotate(0, Time.deltaTime * 100f * speed, 0);
            currentTime += Time.deltaTime;
            if(currentTime >= duration) {
                Destroy(this.gameObject);
            }
        }
    }
    public virtual void Shot(Vector3 direction, float damage) {
        this.direction = direction;
        this.damage = damage;
        isShot = true;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
    }
}
