using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GPTFreeLookCamContr : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    private Image _sensor;
    [SerializeField] private CinemachineFreeLook _cinemachineFreeLook;
    [SerializeField] private string _strMouseX = "Mouse X", _strMouseY = "Mouse Y";
    [SerializeField] private float _cameraSensitivity;
    private float _speedX;
    private float _speedY;
    private Vector2 _startTouchPosition;

    private void Start()
    {
        _sensor = GetComponent<Image>();
        _speedX = _cinemachineFreeLook.m_XAxis.m_MaxSpeed;
        _speedY = _cinemachineFreeLook.m_YAxis.m_MaxSpeed;
        _cinemachineFreeLook.m_XAxis.m_MaxSpeed = _speedX * _cameraSensitivity;
        _cinemachineFreeLook.m_YAxis.m_MaxSpeed = _speedY * _cameraSensitivity;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentTouchPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _sensor.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out currentTouchPosition))
        {
            // Вычисляем разницу между текущим и начальным положением касания
            Vector2 deltaPosition = currentTouchPosition - _startTouchPosition;

            // Применяем вращение к Cinemachine FreeLook камере
            _cinemachineFreeLook.m_XAxis.m_InputAxisValue = deltaPosition.x * _cameraSensitivity;
            _cinemachineFreeLook.m_YAxis.m_InputAxisValue = deltaPosition.y * _cameraSensitivity;

            // Обновляем начальное положение касания для следующего кадра
            _startTouchPosition = currentTouchPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Сбрасываем значения при отпускании пальца
        _cinemachineFreeLook.m_XAxis.m_InputAxisValue = 0;
        _cinemachineFreeLook.m_YAxis.m_InputAxisValue = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _sensor.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out _startTouchPosition))
        {
            // Устанавливаем начальное положение касания при нажатии
        }
    }
}
