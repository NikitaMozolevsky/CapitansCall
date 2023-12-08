using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GPTCameraControl : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public CinemachineFreeLook cinemachineFreeLook;
    public Image touchPanel; // Image компонент вашей панели для отслеживания касаний

    public bool isDragging = false;
    private Vector2 dragStartPosition;

    void Update()
    {
        if (isDragging)
        {
            // Рассчитываем смещение от начальной позиции касания
            Vector2 dragDelta = (Vector2)Input.mousePosition - dragStartPosition;

            // Вычисляем угол вращения на основе смещения
            float rotationFactor = dragDelta.x / Screen.width;

            // Применяем вращение к Cinemachine FreeLook камере
            cinemachineFreeLook.m_XAxis.Value += rotationFactor;

            // Обновляем начальную позицию касания для следующего кадра
            dragStartPosition = Input.mousePosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Запоминаем начальную позицию касания при нажатии на панель
        isDragging = true;
        dragStartPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Сбрасываем флаг при отпускании касания
        isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Метод интерфейса IDragHandler, но в этом случае не требуется, так как мы используем Update
    }
}
