using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsToRightPointer : MonoBehaviour
{
    public GameObject aimPointer;
    public GameObject gunRow;

    public void Update()
    {
        // Проверка на null для aimCube и gunRow, проверка на активность
        if (aimPointer == null && gunRow == null && !aimPointer.activeSelf)
        {
            Debug.LogWarning("AimCube or GunRow is not assigned or !aimPointer.activeSelf.");
            return;
        } 

        // Перебор дочерних объектов gunRow
        for (int i = 0; i < gunRow.transform.childCount; i++)
        {
            Transform gun = gunRow.transform.GetChild(i);
            
            // Установка направления вправо от пушки к aimCube
            gun.right = aimPointer.transform.position - gun.position;
        }
    }
}
