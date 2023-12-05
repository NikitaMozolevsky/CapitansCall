using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GPT1DragSprite : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform rectTransform;
    
    // Для нажатия в рандомном месте и сразу же срабатывания другого скрипта для отслеживания мыши
    [SerializeField] private bool isMouseClicked = false;  

    private void Start()
    {
        // Получаем компонент RectTransform изображения
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        MoveObjectToMouseClickPosition();
        if (isMouseClicked)
        {
            SetImagePosition(Input.mousePosition);
        }
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
        RectTransformUtility.ScreenPointToLocalPointInRectangle
            (rectTransform.parent as RectTransform, position, null, out Vector2 localPos);

        // Устанавливаем новую позицию изображения
        rectTransform.localPosition = localPos;
    }
    
    public void MoveObjectToMouseClickPosition()
    {
        // Проверяем, было ли совершено нажатие мыши
        if (Input.GetMouseButtonDown(0))
        {
            isMouseClicked = true;
            // Получаем текущую позицию мыши
            Vector2 mousePosition = Input.mousePosition;

            // Преобразуем экранные координаты в локальные координаты Canvas
            RectTransformUtility.ScreenPointToLocalPointInRectangle
                (rectTransform.parent as RectTransform, mousePosition, null, out Vector2 localPos);

            // Устанавливаем новую позицию изображения
            rectTransform.localPosition = localPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseClicked = false;
        }
    }
}
