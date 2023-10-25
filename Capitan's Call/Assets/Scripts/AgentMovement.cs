using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    [SerializeField]private GameObject startPoint; // Начальная точка маршрута
    [SerializeField]private GameObject endPoint; // Конечная точка маршрута

    private NavMeshAgent navMeshAgent;
    private Vector3 currentDestination;

    [SerializeField]
    private bool isEnemyShip; // Вражеский корабль 

    private float timer = 0f; // Таймер для обновления цели
    public float changeDestinationInterval = 15.0f; // Интервал для смены цели

    private void Start()
    {
        SetStartEndPoints(); // Добавил т.к. шибка из-за отсувствия точек старта и конца у объектов
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Назначаем случайную начальную цель
        MoveToRandomDestination();
    }

    private void Update()
    {
        // Обновляем таймер
        timer += Time.deltaTime;

        // Если прошло достаточно времени, меняем цель
        if (timer >= changeDestinationInterval)
        {
            MoveToRandomDestination();
            timer = 0f; // Сбрасываем таймер
        }
    }

    private void MoveToRandomDestination()
    {
        if (navMeshAgent != null)
        {
            // Генерируем случайную цель в диапазоне между startPoint и endPoint
            Vector3 randomDestination = new Vector3(
                Random.Range(startPoint.transform.position.x, endPoint.transform.position.x),
                startPoint.transform.position.y, // Чтобы оставаться на том же уровне Y
                Random.Range(startPoint.transform.position.z, endPoint.transform.position.z)
            );

            // Назначаем агенту новую цель
            navMeshAgent.SetDestination(randomDestination);
        }
    }

    private void SetStartEndPoints()
    {
        
    }
}
