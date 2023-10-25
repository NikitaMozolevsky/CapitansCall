using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]private GameObject startPoint; // Начальная точка (минимальное значение X и Z)
    [SerializeField]private GameObject endPoint;   // Конечная точка (максимальное значение X и Z)
    public GameObject[] objectsToSpawn; // Массив объектов для создания
    public int numberOfObjectsToSpawn = 5; // Количество объектов для создания
    public float yOffset = 1.0f; // Смещение по оси Y

    private void Start()
    {
        // Создать указанное количество объектов в диапазоне между двумя точками
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            SpawnObjectInXZRange();
        }
    }

    void SpawnObjectInXZRange()
    {
        if (startPoint != null && endPoint != null && objectsToSpawn != null && objectsToSpawn.Length > 0)
        {
            // Генерация случайной XZ-позиции в заданном диапазоне
            float randomX = Random.Range(startPoint.transform.position.x, endPoint.transform.position.x);
            float randomZ = Random.Range(startPoint.transform.position.z, endPoint.transform.position.z);

            // Выбор случайного объекта из массива
            GameObject selectedObject = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Создание позиции с учетом Y-смещения
            Vector3 spawnPosition = new Vector3(randomX, yOffset, randomZ);

            // Создайте выбранный объект по этой позиции
            GameObject spawnedObject = Instantiate(selectedObject, spawnPosition, Quaternion.identity);

            // Если у объекта нет компонента AgentMovement, добавьте его
            AgentMovement agentMovement = spawnedObject.GetComponent<AgentMovement>();
            if (agentMovement == null)
            {
                spawnedObject.AddComponent<AgentMovement>();
            }
        }
        else
        {
            Debug.LogError("Please assign the start point, end point, and objects to spawn in the inspector.");
        }
    }
}
