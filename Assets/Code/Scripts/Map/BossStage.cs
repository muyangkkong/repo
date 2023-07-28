using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage : MonoBehaviour
{
    public int stage;
    public GameObject[] stageEnemySet;
    GameObject currentStageEnemySet;

    void Start() {
        stage = 0;
        currentStageEnemySet = Instantiate<GameObject>(stageEnemySet[0]);
    }

    void Update() {
        if(stage == stageEnemySet.Length) //clear;

        Debug.Log(currentStageEnemySet.transform.childCount);

        if(currentStageEnemySet.transform.childCount == 0) {
            stage++;
            currentStageEnemySet = Instantiate<GameObject>(stageEnemySet[stage]);
        }
    }
}
