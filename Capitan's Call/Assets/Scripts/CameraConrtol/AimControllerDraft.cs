using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimControllerDraft : MonoBehaviour
{
    #region Editor Settings

    [SerializeField] private LayerMask groundMask;

    #endregion

    #region Private Fields

    private Camera mainCamera;

    #endregion

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Aim();
    }

    private (bool success, Vector3 position) GetMousePosition()
    { 
        // Получение луча который пройдет через мышь
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Возвращает true или false в зависимости от того попал ли луч во что-то
        // groundMask для игнорирования коллайдеров на определенных физических слоях
        // т.е. целится в стену или нет
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        { // Если попал во что-то
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();

        if (success)
        {   
            // Получение направления
            var direction = position - transform.position;
            
            // установление послоянной высоты высоты
            /*direction.y = 0;*/
            
            // Поворот объекта в нужном направлении
            transform.right = direction;
        }
    }

}
