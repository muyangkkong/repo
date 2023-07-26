using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingBarManager : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;

    public float timerSpeed;
    bool isTimerOn;
    Slider slider;

    //AttackTree attackTree = new AttackTree();

    int[,] nextAttackInfo = new int[5,2];
    GameObject[,] indicator = new GameObject[5,2];

    void Start()
    {
        slider = GetComponent<Slider>();
        isTimerOn = false;
        slider.value = 0;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.volume = 1.0f;
        audioSource.pitch = timerSpeed / 2.0f;

        indicator[1,0] = GameObject.Find("Indicator1").transform.Find("IndicatorA").gameObject;
        indicator[1,1] = GameObject.Find("Indicator1").transform.Find("IndicatorB").gameObject;
        indicator[2,0] = GameObject.Find("Indicator2").transform.Find("IndicatorA").gameObject;
        indicator[2,1] = GameObject.Find("Indicator2").transform.Find("IndicatorB").gameObject;
        indicator[3,0] = GameObject.Find("Indicator3").transform.Find("IndicatorA").gameObject;
        indicator[3,1] = GameObject.Find("Indicator3").transform.Find("IndicatorB").gameObject;
        indicator[4,0] = GameObject.Find("Indicator4").transform.Find("IndicatorA").gameObject;
        indicator[4,1] = GameObject.Find("Indicator4").transform.Find("IndicatorB").gameObject;
    }

    void FixedUpdate()
    {
        if(isTimerOn) {
            slider.value += Time.deltaTime * timerSpeed;
            if(slider.value >= slider.maxValue) {
                isTimerOn = false;
                slider.value = 0;
            }
        }
        if(Input.GetKey(KeyCode.T)) {
            TimerStart();
        }
    }

    public void TimerStart() {
        slider.value = 0;
        isTimerOn = true;
        audioSource.Play();

        SetIndicator();
    }

    public void TimerReset() {
        slider.value = 0;
        isTimerOn = false;

        SetIndicator();
    }

    public void SetIndicator() {
        for(int i = 1; i <= 4; i++) {
            for(int j = 0; j < 2; j++) {
                indicator[i,j].SetActive(nextAttackInfo[i,j] != 0);
            }
        }
    }

    public bool GetTimerState() {
        return isTimerOn;
    }

    public float GetTimerValue() {
        return slider.value;
    }
    
    public void SetAttackInfo(int[,] attackInfo) {
        nextAttackInfo = attackInfo;
    }
}
