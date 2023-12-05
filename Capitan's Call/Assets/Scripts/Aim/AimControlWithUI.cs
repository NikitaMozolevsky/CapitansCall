using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AimControlWithUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private bool isDragging = false;

    void Start()
    {
        // Получаем компоненты
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Начало перетаскивания
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Перетаскивание в соответствии с движением указателя
        if (isDragging)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position, canvas.worldCamera, out pos);

            // Ограничиваем позицию в пределах границ канваса
            pos.x = Mathf.Clamp(pos.x, 
                canvas.GetComponent<RectTransform>().rect.xMin + 30f, 
                canvas.GetComponent<RectTransform>().rect.xMax - 30f);
            pos.y = Mathf.Clamp(pos.y, 
                canvas.GetComponent<RectTransform>().rect.yMin + 30f, 
                canvas.GetComponent<RectTransform>().rect.yMax - 30f);

            rectTransform.anchoredPosition = pos;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Окончание перетаскивания
        isDragging = false;
    }
}
