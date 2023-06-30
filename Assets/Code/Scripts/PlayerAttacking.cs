using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
        private GameObject attackArea;
        public GameObject instrument;



        public bool attacking = false;

        public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        instrument.GetComponent<Instrument>().Construct();
        instrument.GetComponent<Instrument>().Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            timer+=Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {   
            attacking = true;
            instrument.GetComponent<Instrument>().AttackA();

        }
        if (Input.GetMouseButtonDown(1))
        {
            attacking = true;
            instrument.GetComponent<Instrument>().AttackB();

        }
    }
}
