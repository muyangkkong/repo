using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Loading : MonoBehaviour
{
    static string nextScene;

    [SerializeField]
    Image progressbar;

    [SerializeField]
    TextMeshProUGUI progressText; // TextMeshProUGUI 컴포넌트를 연결할 변수

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading"); // 로딩 씬으로 전환
    }

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float loadingTime = 3f; // 로딩 시간 (초단위)
        float timer = 0f;

        while (!op.isDone)
        {
            yield return null;

            if (progressbar.fillAmount < 1f)
            {
                timer += Time.deltaTime;
                progressbar.fillAmount = Mathf.Lerp(0f, 1f, timer / loadingTime);

                // 로딩 진행 상태를 텍스트로 표시
                int progressPercent = Mathf.RoundToInt(progressbar.fillAmount * 100f);
                progressText.text = progressPercent.ToString() + "%"; // % 문자 추가
            }
            else
            {
                // 로딩 바가 완전히 채워졌을 때 Scene 활성화
                op.allowSceneActivation = true;
                yield break;
            }
        }
    }
}