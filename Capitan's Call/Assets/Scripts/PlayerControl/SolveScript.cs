using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SalvoScript : MonoBehaviour
{

    public float force = 10000f;
    public GameObject missilePrefab;
    public GameObject gunRow;
    private bool[] cannonsFired;
    private int childCount;

    private void Start()
    { 
        childCount = gunRow.transform.childCount; // Получение количества пушек
        cannonsFired = new bool[childCount]; // Массив для определения какая пушка выстрелила
    }

    public void Salvo()
    {
        StartCoroutine(FireCannonsWithDelay());
    }

    private void Update() // При нажатии "V"
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(FireCannonsWithDelay());
        }
    }

    IEnumerator FireCannonsWithDelay()
    {
        List<int> availableCannons = new List<int>(); // Доступные пушки
        for (int i = 0; i < childCount; i++)
        {
            if (!cannonsFired[i]) // Выстрелила ли пушка
            {
                availableCannons.Add(i); // Добавление в массив доступных пушек
            }
        }

        while (availableCannons.Count > 0) // Если есть доступные пушки
        {
            int randomIndex = Random.Range(0, availableCannons.Count); // Рандомное число
            int cannonIndex = availableCannons[randomIndex]; // Пушка под этим индексом
            availableCannons.RemoveAt(randomIndex); // Удаление из доступных пушек

            if (!cannonsFired[cannonIndex]) // Если пушка еще не выстреливала
            {
                cannonsFired[cannonIndex] = true; // Изменение bool значения

                // Получение точки выстрела
                Transform missilePoint = gunRow.transform.GetChild(cannonIndex).GetChild(0);
                // GPT Преобразование локальных координат в глобальные
                Vector3 globalDirection = missilePoint.TransformDirection(Vector3.right); 
                // Создание снаряда
                GameObject missile = Instantiate(missilePrefab, missilePoint.position, missilePoint.rotation);
                Rigidbody missileRb = missile.GetComponent<Rigidbody>();
                missileRb.AddForce(globalDirection * force, ForceMode.Force); // Используем глобальные координаты
                
                StartCoroutine(DestroyMissileAfterTime(missile, 5f)); // Удаление ядра через 5 секунд 
            }
            yield return new WaitForSeconds(Random.Range(0.1f, 0.2f)); // Небольшая задержка между выстрелами
        }

        // Сброс флагов для следующего выстрела
        for (int i = 0; i < childCount; i++)
        {
            cannonsFired[i] = false;
        }
        
        IEnumerator DestroyMissileAfterTime(GameObject missile, float delay)
        {
            yield return new WaitForSeconds(delay);
            if (missile != null)
            {
                Destroy(missile); // Уничтожение через delay секунд
            }
        }
        
        // Уничтожение при соприкосновении
        /*void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("OtherObjectTag"))
            {
                Destroy(collision.gameObject); // Удаление другого объекта
            }
        }*/
    }
}
