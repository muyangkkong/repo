using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingBarManager : MonoBehaviour
{
    bool isTimerOn;
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        isTimerOn = false;
        slider.value = 0;
    }

    void Update()
    {
        if(isTimerOn) {
            slider.value += Time.deltaTime;
        }
    }

    public void TimerStart() {
        slider.value = 0;
        isTimerOn = true;
    }
    public bool getTimerState() {
        return isTimerOn;
    }

    public float getTimerValue() {
        return slider.value;
    }
}
