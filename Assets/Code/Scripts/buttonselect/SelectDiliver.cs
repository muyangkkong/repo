using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDiliver : MonoBehaviour
{   
    private static SelectDiliver instance = null;
    public static SelectDiliver Instance
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

    Instrument select = null;
    public Instrument Select
    {
        get
        {
            return select;
        }
        set
        {
            select = value;
        }
    }

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
