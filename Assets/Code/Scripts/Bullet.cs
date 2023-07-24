using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    GameObject targetplayer;
    CharacterHP Chp;
    Rigidbody playerrigid;
    public float knockbackDuration = 0.3f;
    void Start()
    {
        targetplayer = GameObject.Find("Player");
        Chp = targetplayer.GetComponent<CharacterHP>();
        playerrigid = targetplayer.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject, 3);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            Chp.getDamage(5.0f);
            Vector3 knockbackDirection = (transform.forward).normalized;
            StartCoroutine(KnockbackCoroutine(playerrigid, knockbackDirection, 3000f));
            Destroy(gameObject);
        }
    }
    IEnumerator KnockbackCoroutine(Rigidbody targetRigidbody, Vector3 knockbackDirection, float knockbackForce)
    {

        float timer = 0f;
        while (timer < knockbackDuration)
        {
            // 넉백 완화
            float knockbackForceThisFrame = Mathf.Lerp(knockbackForce, 0f, timer / knockbackDuration);

            // 넉백 가하기
            targetRigidbody.AddForce(knockbackDirection * knockbackForceThisFrame);

            // 시간 업데이트
            timer += Time.deltaTime;


            yield return null;
        }

    }
}