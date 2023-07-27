using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform buttonRectTransform;
    public Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1.2f);
    public float hoverDuration = 0.2f;

    private void Start()
    {
        buttonRectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(buttonRectTransform, hoverScale, hoverDuration);
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(buttonRectTransform, Vector3.one, hoverDuration);
    }
}