using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class appearblock1 : MonoBehaviour
{
    private Image image;
   
 
    // Start is called before the first frame update
    private void Awake()
    {
       image =GetComponent<Image>();
       
        
    }
    void Start(){
        
        StartCoroutine(FadeInCoroutine());
        
    }

    // Update is called once per frame
    IEnumerator FadeInCoroutine()
  {
    yield return new WaitForSeconds(10.0f); // 10초 대기

    // 10초 후에 실행될 페이드 인 동작 수행
    float fadeDuration = 3.0f;
    float timer = 0.0f;

    while (timer < fadeDuration)
    {
        timer += Time.deltaTime;

        float alpha = Mathf.Lerp(0.0f, 1.0f, timer / fadeDuration);
        Color color = image.color;
        color.a = alpha;
        image.color = color;

        yield return null;
    }
     Debug.Log("두둥장");
   }





    
    
}
