using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    public Transform targetTransform;
    public LayerMask layerMask;
    private GameObject currentPoint;
    public GameObject rightAimPoint;
    public GameObject leftAimPoint;

    private void Update()
    {
        DrawRay();
        /*Ray ray = new Ray(transform.position, -Vector3.up);
        Debug.DrawRay(ray.origin, ray.direction * 10f);*/
    }

    private void DrawRay()
    {
        RaycastHit hit;
        // Луч в точку прицела
        Ray ray = new Ray(transform.position, (targetTransform.position - transform.position).normalized);
        // Отрисовка луча
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 1000f, Color.red);
        
        // Если одна из точек активна
        // Что делает точку активной ? Right/LeftView Couroutine.
        if (rightAimPoint.activeSelf || leftAimPoint.activeSelf)
        {
            currentPoint = rightAimPoint.activeSelf ? rightAimPoint : leftAimPoint; // Какая точка активна ?
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                // Обработка столкновения с объектом на физическом слое "AimCube"
                Debug.Log("Hit object on layer QWE: " + hit.collider.gameObject.name);
                currentPoint.transform.position = hit.point; // Изменение позиции точки цели
                currentPoint.GetComponent<GunsToPointer>().enabled = true;
            }
            else
            {
                // Обработка отсутствия столкновения
                Debug.Log("No collision with layer QWE");
                
            }
        }
        else
        {
            if (currentPoint != null)
            {
                currentPoint.GetComponent<GunsToPointer>().enabled = false;
                currentPoint.SetActive(false);
            }
        }
    }

    /*private void OnDrawGizmos()
    {
        // Получаем позицию камеры
        Vector3 cameraPosition = Camera.main.transform.position;

        // Отображаем бесконечный луч от камеры через точку targetTransform
        Gizmos.color = Color.red;
        Gizmos.DrawLine(cameraPosition, targetTransform.position);
    }*/
}
