using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateGuageManager : MonoBehaviour
{
    static UltimateGuageManager instance;
    public static UltimateGuageManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    Slider slider;

    void Awake() {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        slider = GetComponent<Slider>();
    }

    public void AddValue(float yieldGuage) {
        slider.value += yieldGuage;
    }
}
