using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicSlot : MonoBehaviour
{
    [SerializeField] Image image;

    private Relic _Relic;
    public Relic relic {
        get {return _Relic;}
        set {
            _Relic=value;
            if (_Relic != null){
                image.sprite = _Relic.RelicImage;
                image.color = new Color(1,1,1,1);
            } else {
                image.color = new Color(1,1,1,0);
            }
        }
    }
}
