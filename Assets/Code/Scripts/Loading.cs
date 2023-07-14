using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Slider progressbar; // 로딩 바 슬라이더
    public float delayTime = 1.5f; // 로딩 바가 100%로 채워진 후 대기할 시간

    private bool loadingComplete = false; // 로딩 완료 여부

    private void Start()
    {
        progressbar = GameObject.Find("Slider").GetComponent<Slider>(); // GameObject에서 Slider 컴포넌트를 찾아 할당
        StartCoroutine(LoadScene()); // 코루틴으로 LoadScene 호출
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation operation = SceneManager.LoadSceneAsync("3dScene"); // 3D Scene 비동기 로드
        operation.allowSceneActivation = false; // Scene 활성화 지연

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // 실제 진행도 계산

            Debug.Log("Loading progress: " + progress);
            Debug.Log("Is loading complete? " + operation.isDone);

            if (progressbar.value < progress) // 로딩 진행도가 실제 진행도보다 작을 경우
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, progress, Time.deltaTime * 0.5f); // 로딩 바 증가
            }

            if (progressbar.value >= 1f && progress >= 1f) // 로딩 바와 실제 진행도가 모두 100% 이상인 경우
            {
                loadingComplete = true; // 로딩 완료 상태로 변경
                yield return new WaitForSeconds(delayTime); // 대기 시간 동안 대기
                operation.allowSceneActivation = true; // Scene 활성화
            }

            yield return null;
        }
    }
}











