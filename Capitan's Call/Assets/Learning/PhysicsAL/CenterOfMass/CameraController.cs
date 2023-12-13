using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float sensitivity = 2.0f; // Чувствительность вращения камеры

    void Update()
    {
        // Получаем значения ввода с мыши
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Поворачиваем камеру вокруг осей X и Y
        transform.Rotate(Vector3.up, mouseX * sensitivity);
        transform.Rotate(Vector3.left, mouseY * sensitivity);

        // Ограничиваем углы вращения камеры по оси Y между -90 и 90 градусов
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -360f, 360f);
        transform.localEulerAngles = currentRotation;
    }
}
