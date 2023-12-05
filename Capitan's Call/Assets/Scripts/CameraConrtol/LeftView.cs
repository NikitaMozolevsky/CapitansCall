using System;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine;

public class LeftView : MonoBehaviour
{
    [SerializeField] private CinemachineStateDrivenCamera _leftCamera;
    private int _lowPriority = 9;
    private int _highPriority = 11;
    
    [SerializeField] private bool _isFirstClick = true;
    [SerializeField] private GameObject _leftSalvoButton; // Нужно включить при нажатии
    [SerializeField] private GameObject _rightViewButton; // Нужно выключить при нажатии
    [SerializeField] private GameObject _aimPointer; // Прицел

    public void OnClick()
    {
        if (_isFirstClick)
        { // Включение кнопки
            _isFirstClick = false;
            _leftCamera.Priority = _highPriority;
            _rightViewButton.SetActive(false);
            _leftSalvoButton.SetActive(true);
            _aimPointer.SetActive(true);

        }
        else
        { // Выключение кнопки
            _isFirstClick = true;
            _leftCamera.Priority = _lowPriority;
            _leftSalvoButton.SetActive(false);
            _rightViewButton.SetActive(true);
            _aimPointer.SetActive(false);
        }
    }

    public void Update()
    {
        if (!_isFirstClick) // Если кнопка была нажата
        {
            
        }
    }
}
