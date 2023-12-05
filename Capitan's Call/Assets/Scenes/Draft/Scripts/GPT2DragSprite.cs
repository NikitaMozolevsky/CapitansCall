using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GPT2DragSprite : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private bool isDragging = false;

    private void Start()
    {
        // Получаем компоненты RectTransform, Canvas и CanvasGroup
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Начало перетаскивания
        isDragging = true;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Перетаскивание объекта
        if (isDragging)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out Vector2 localPos);
            rectTransform.position = canvas.transform.TransformPoint(localPos);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Завершение перетаскивания
        isDragging = false;
        canvasGroup.blocksRaycasts = true;
    }
}
