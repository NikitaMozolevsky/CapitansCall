using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ALFreeLookCamContr : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    private Image _sensor;
    [SerializeField] private CinemachineFreeLook _cinemachineFreeLook;
    [SerializeField] private string _strMouseX = "Mouse X", _strMouseY = "Mouse Y";
    [SerializeField] private float _cameraSensitivity;
    private float _speedX;
    private float _speedY;

    private void Start()
    {
        _sensor = GetComponent<Image>();
        _speedX = _cinemachineFreeLook.m_XAxis.m_MaxSpeed;
        _speedY = _cinemachineFreeLook.m_YAxis.m_MaxSpeed;
        _cinemachineFreeLook.m_XAxis.m_MaxSpeed = _speedX * _cameraSensitivity;
        _cinemachineFreeLook.m_YAxis.m_MaxSpeed = _speedY * _cameraSensitivity;
    }

    /*public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _sensor.rectTransform,
                eventData.position,
                eventData.enterEventCamera,
                out Vector2 posOut))
        {
            Debug.Log(posOut);
            _cinemachineFreeLook.m_XAxis.m_InputAxisName = _strMouseX;
            _cinemachineFreeLook.m_YAxis.m_InputAxisName = _strMouseY;
        }
    }*/
    
    public void OnDrag(PointerEventData eventData) // GPT
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _sensor.rectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 posOut))
        {
            Debug.Log(posOut);

            // Используйте posOut для управления камерой в соответствии с вашей логикой

            _cinemachineFreeLook.m_XAxis.m_InputAxisValue = posOut.x * _cameraSensitivity;
            _cinemachineFreeLook.m_YAxis.m_InputAxisValue = posOut.y * _cameraSensitivity;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _cinemachineFreeLook.m_XAxis.m_InputAxisName = null; // Убирание для отключения отслеживания мыши
        _cinemachineFreeLook.m_YAxis.m_InputAxisName = null; // Убирание для отключения отслеживания мыши
        _cinemachineFreeLook.m_XAxis.m_InputAxisValue = 0;
        _cinemachineFreeLook.m_XAxis.m_InputAxisValue = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
}
