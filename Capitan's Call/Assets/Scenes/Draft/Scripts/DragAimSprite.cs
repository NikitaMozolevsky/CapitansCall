using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAimSprite : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    
    private RectTransform rectTransform;

    private void Start()
    {
        // Получаем компонент RectTransform изображения
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetPosition(Transform obj)
    {
        obj.position = Input.mousePosition;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        // Вызывается при нажатии кнопки мыши (или касания)
        SetImagePosition(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Вызывается при перемещении мыши (или пальца) после нажатия
        SetImagePosition(eventData.position);
    }

    private void SetImagePosition(Vector2 position)
    {
        // Преобразуем экранные координаты в локальные координаты Canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, position, null, out Vector2 localPos);

        // Устанавливаем новую позицию изображения
        rectTransform.localPosition = localPos;
    }
    
}
