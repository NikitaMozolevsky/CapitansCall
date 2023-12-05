using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using Random = UnityEngine.Random;

public class SalvoScript1 : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    private List<GameObject> gunList = new List<GameObject>();
    public bool salvoIsReady = true;
    public bool rowIsntSetted = true;
    // Сила выстрела
    public float power = 2000f;
    private void Start()
    { // Заполенение массива
        if (rowIsntSetted)
        {
            gunList = getGunList();
            rowIsntSetted = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && salvoIsReady)
        { 
            StartCoroutine((IEnumerator)Salvo(gunList));
        }
    }

    private List<GameObject> getGunList()
    {
        List<GameObject> gunList = new List<GameObject>();
        // Кол-во дочерних объектов
        int childCount = transform.childCount;
        // Помещение пушек в List
        for (int i = 0; i < childCount; i++)
        {
            GameObject gun = transform.GetChild(i).gameObject;
            gunList.Add(gun);
        }

        return gunList;
    }

    private IEnumerable<WaitForSeconds> Salvo(List<GameObject> gunList)
    {
        salvoIsReady = false;
            
            // Создание каждого снаряда
            foreach (var gun in gunList)
            {
                GameObject missile = Instantiate(missilePrefab) as GameObject;
                // Установление в точке
                missile.transform.position = gun.transform.GetChild(0).position;
                missile.transform.rotation = gun.transform.GetChild(0).rotation;
                // 1 - Направление силы на скорость, 2 - тип прилаж. силы
                missile.GetComponent<Rigidbody>().AddRelativeForce(missile.transform.forward * power, ForceMode.Force);
            }
            
            yield return new WaitForSeconds(5f); // Перезарядка
            salvoIsReady = true; // Перезарядилось
        }
}
