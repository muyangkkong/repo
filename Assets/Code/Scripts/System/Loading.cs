using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Slider progressbar; // 로딩바 슬라이더
    public Image loadingImage; // 로딩 진행 상황에 따라 나타날 이미지
    public float revealSpeed = 1f; // 이미지가 나타날 속도

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("3dScene");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;

            // 로딩 진행 상황에 따라 로딩바 조절
            float targetProgress = operation.progress < 0.9f ? 0.9f : 1f;
            progressbar.value = Mathf.MoveTowards(progressbar.value, targetProgress, Time.deltaTime);

            // 로딩 진행 상황에 따라 이미지 표시
            float alphaValue = progressbar.value - 0.9f;
            Color imageColor = loadingImage.color;
            imageColor.a = alphaValue;
            loadingImage.color = imageColor;

            // 로딩이 완료되고 이미지가 완전히 나타났을 때 씬 전환
            if (progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
