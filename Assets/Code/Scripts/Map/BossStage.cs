using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage : MonoBehaviour
{
    public int stage;
    public GameObject[] stageEnemySet;
    GameObject currentStageEnemySet = null;

    void Start() {
        stage = -1;
    }

    void Update() {
        if(currentStageEnemySet == null || currentStageEnemySet.transform.childCount == 0) {
            stage++;
            if(stage == stageEnemySet.Length) return;
            currentStageEnemySet = Instantiate<GameObject>(stageEnemySet[stage]);
        }
    }
}
