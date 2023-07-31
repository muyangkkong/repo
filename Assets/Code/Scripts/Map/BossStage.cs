using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStage : MonoBehaviour
{
    public int stage;
    public GameObject[] stageEnemySet;
    GameObject currentStageEnemySet = null;

    void Start() {
        stage = -1;
    }

    void Update()
    {

        if (currentStageEnemySet == null || currentStageEnemySet.transform.childCount == 0)
        {
            stage++;
            if (stage == stageEnemySet.Length)
            {

                StartCoroutine(LoadThanksSceneAfterDelay(1f));
                return;
            }
            currentStageEnemySet = Instantiate<GameObject>(stageEnemySet[stage]);
        }
    }

    IEnumerator LoadThanksSceneAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        Background backgroundInstance = GameObject.FindObjectOfType<Background>();
        if (backgroundInstance != null)
            Destroy(backgroundInstance.gameObject);

        SceneManager.UnloadSceneAsync("Map");
        Destroy(MapManager.Instance.gameObject);
        SceneManager.LoadScene("Thanks", LoadSceneMode.Single);
    }

}