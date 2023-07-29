using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    void Update() {
        this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
