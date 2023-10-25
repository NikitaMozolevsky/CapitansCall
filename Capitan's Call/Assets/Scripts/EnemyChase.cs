using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private float radius = 70f;
    [SerializeField] private Collider[] hitColliders;
    private void Update()
    {
        // Если вражеский корабль - проверяет есть ли игрок рядом,
        // если да - выключает скрипт AgentMovement начинает скрипт EnemyChase
        if (CheckIfPlayerIsNearby())
        {
            SetChase();
        }
        
    }

    private bool CheckIfPlayerIsNearby()
    { // Отслеживание сферического прикосновения всех возможных коллайдеров
        // помещение всех коллайдеров в массив
        // a - центр сферы отслеживания
        // b - радиус сферы
        hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var el in hitColliders)
        {
            if (gameObject.CompareTag("Enemy") && el.gameObject.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;   
    }

    private void SetChase()
    {
        GetComponent<AgentMovement>().enabled = false; // выключение 
        GetComponent<AgentMovement>().enabled = true;
        
    }
    
}
