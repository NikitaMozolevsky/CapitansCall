using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swaying : MonoBehaviour
{
    
    public float rockingSpeed = 2f; // Скорость покачивания
    public float maxRotation = 2f;
    public float minRotation = -2f;
    public float DTMultiplayer = 1f;

    private void Update()
    {
        // Генерируем случайные значения для покачивания
        float randomRotationX = Random.Range(minRotation, maxRotation);
        float randomRotationZ = Random.Range(minRotation, maxRotation);

        // Выполняем покачивание по X и Z
        MyRockShip(randomRotationX, randomRotationZ);
    }

    private void RockShip(float rotationX, float rotationZ)
    {
        // Получаем текущую ротацию корабля
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Применяем случайные изменения к ротации по X и Z
        currentRotation.x = rotationX * rockingSpeed * Time.deltaTime;
        currentRotation.z = rotationZ * rockingSpeed * Time.deltaTime;

        // Применяем измененную ротацию к кораблю
        transform.rotation = Quaternion.Euler(currentRotation);
    }
    
    private void MyRockShip(float rotationX, float rotationZ)
    {
        // Получаем текущую ротацию корабля
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Применяем случайные изменения к ротации по X и Z
        currentRotation.x = rotationX * rockingSpeed * Time.deltaTime * DTMultiplayer;
        currentRotation.z = rotationZ * rockingSpeed * Time.deltaTime * DTMultiplayer;

        // Применяем измененную ротацию к кораблю
        transform.rotation = Quaternion.Euler(currentRotation);
    }
    
}
