using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StopCinemachIfNonClickedPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public CinemachineFreeLook _cinemachineFreeLook;
    public const float _XStartMaxSpeed = 300;
    public const float _YStartMaxSpeed = 2;
    public float timeToDecrease = 2.0f;
    public float inertiaMultiplier = 2.0f; // Множитель инерции
    private bool isClicked = false;
    private Coroutine decreaseSpeedCoroutine; // Для управления запуском и стопом одной и той же куратины
    private Vector3 lastMousePosition;

    private void Start()
    {
        _cinemachineFreeLook.m_XAxis.m_MaxSpeed = 0;
        _cinemachineFreeLook.m_YAxis.m_MaxSpeed = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
        _cinemachineFreeLook.m_XAxis.m_MaxSpeed = _XStartMaxSpeed;
        _cinemachineFreeLook.m_YAxis.m_MaxSpeed = _YStartMaxSpeed;
        lastMousePosition = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
        _cinemachineFreeLook.m_XAxis.m_MaxSpeed = 0;
        _cinemachineFreeLook.m_YAxis.m_MaxSpeed = 0;
        /*decreaseSpeedCoroutine = StartCoroutine(DecreaseSpeedOverTime(timeToDecrease));*/
    }

    IEnumerator DecreaseSpeedOverTime(float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float inertiaFactor = 1.0f;

            // Если кнопка не нажата, учитываем инерцию
            if (!isClicked)
            {
                Vector3 currentMousePosition = Input.mousePosition;
                float mouseDelta = (currentMousePosition - lastMousePosition).magnitude;
                inertiaFactor = 1.0f + mouseDelta * inertiaMultiplier;
                lastMousePosition = currentMousePosition; // Обновляем положение мыши для следующего кадра
            }

            // Используйте Mathf.Lerp для постепенного уменьшения скорости с учетом инерции
            _cinemachineFreeLook.m_XAxis.m_MaxSpeed = Mathf.Lerp(_XStartMaxSpeed, 0, elapsedTime / duration) * inertiaFactor;
            _cinemachineFreeLook.m_YAxis.m_MaxSpeed = Mathf.Lerp(_YStartMaxSpeed, 0, elapsedTime / duration) * inertiaFactor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Гарантировать, что значения точно равны 0 в конце
        _cinemachineFreeLook.m_XAxis.m_MaxSpeed = 0;
        _cinemachineFreeLook.m_YAxis.m_MaxSpeed = 0;

        decreaseSpeedCoroutine = null; // Корутина завершена
    }
}