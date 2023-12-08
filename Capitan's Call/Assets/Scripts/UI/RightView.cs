using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class RightView : MonoBehaviour
{

    [SerializeField] private CinemachineStateDrivenCamera _rightCamera;
    private int _lowPriority = 9;
    private int _highPriority = 11;
    [SerializeField] private bool _isFirstClick = true; // Первое ли нажатие
    [SerializeField] private GameObject _rightSalvoButton; // Кнопка залпа
    [SerializeField] private GameObject _leftViewButton; // Кнопка вида (нужно выключить)
    [SerializeField] private GameObject _aimPointer; // Точка на Canvas
    [SerializeField] private GameObject _rightGunPoint; // Точка правого огня
    [SerializeField] private bool _coroutineIsStarted; // Прерывает куратину

    

    public void OnClick()
    { // При первом нажатии кнопки
        if (_isFirstClick)
        {
            _isFirstClick = false;
            _rightCamera.Priority = _highPriority; // Повышение приоритета
            _leftViewButton.SetActive(false);
            _rightSalvoButton.SetActive(true); // Показ кнопки залпа
            _aimPointer.SetActive(true);
            StartCoroutine(ActivationRightPoint());

        }
        else
        {
            _isFirstClick = true;
            _rightCamera.Priority = _lowPriority; // Понижение приоритета
            _rightSalvoButton.SetActive(false);
            _leftViewButton.SetActive(true); // Показать кнопку Вида с лева
            _aimPointer.SetActive(false);
            if (_coroutineIsStarted)
            {
                StopCoroutine(ActivationRightPoint());
            }
            else
            {
                _rightGunPoint.SetActive(false);
            }
        }
    }

    IEnumerator ActivationRightPoint()
    {
        _coroutineIsStarted = true;
        yield return new WaitForSeconds(2f);
        _rightGunPoint.SetActive(true);
        _coroutineIsStarted = false;
    }
}
