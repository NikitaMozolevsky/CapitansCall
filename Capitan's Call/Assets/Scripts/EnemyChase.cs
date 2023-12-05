using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 140f;
    [SerializeField] private float attackRadius = 70f;
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private Collider[] hitColliders;

    private void Update()
    {
        // Если вражеский корабль - проверяет есть ли игрок рядом,
        // если да - выключает скрипт AgentMovement начинает скрипт EnemyChase
        ChaseIfPlayerNearby();

    }

    private void ChaseIfPlayerNearby()
    {
        // Отслеживание сферического прикосновения всех возможных коллайдеров
        // помещение всех коллайдеров в массив
        // a - центр сферы отслеживания
        // b - радиус сферы
        hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (var el in hitColliders)
        {
            if (gameObject.CompareTag("Enemy") && el.gameObject.CompareTag("Player"))
            {
                GetComponent<AgentMovement>().enabled = false; // OFF скрипта стандартного движения
                // Включение скрипта стрельбы, он включается и должен провести хотя бы один выстрел

                // На случай если у разных NPC будут действовать разные поведения
                if (gameObject.CompareTag("Enemy"))
                {
                    // Костыль т.к. отключается
                    GetComponent<NavMeshAgent>().enabled = true;
                    // Движение врага к Player
                    GetComponent<NavMeshAgent>().SetDestination(el.transform.position);
                    // collider - получает collider агента попавшего в радиус атаки
                    Collider[] agentColliders = Physics.OverlapSphere(transform.position, attackRadius);
                    // Функция поворота к нужному кораблю
                    TurnSidewayToPlayer(agentColliders, el);
                    // Залп Salvo принимает точку в которую полетит снаряд (точки цели) в туториале
                    // Сделаю в отдельном скрипте, для каждй пушки
                    /*StartCoroutine(Salvo());*/
                }
            }
            else
            {
                GetComponent<AgentMovement>().enabled = true;
            }
            
        }
    }

    public void TurnSidewayToPlayer(Collider[] agentColliders, Collider el)
    {
        foreach (var aim in agentColliders)
        {
            if (aim == el)
            {
                // Отмена движения к игроку
                GetComponent<NavMeshAgent>().enabled = false;

                // Вычисляем вектор от врага к игроку
                Vector3 directionToPlayer = (aim.transform.position - transform.position).normalized;

                // Вычисляем вектор, соответствующий боковой части объекта
                Vector3 localRight = Vector3.Cross(Vector3.up, directionToPlayer);

                // Находим кватернион, соответствующий этому направлению
                Quaternion targetRotation = Quaternion.LookRotation(localRight, Vector3.up);

                // Плавно поворачиваем врага в этом направлении
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                GetComponent<NavMeshAgent>().enabled = true;
            }
        }
    }
    
    
}