using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] 
public class MyQuaternion : MonoBehaviour
{
    public Quaternion _quaternion;
    
    public Transform _first;
    public Transform _second;

    private void Update()
    {
        transform.rotation = _quaternion; // manualy
        LookToAnotherObject(main:_first, aim:_second); // вращает в направлении объекта
        /*SlerpMethod();*/
        
        // Пример использования.
        // ExampleMethod(param1: 42, param2: 3.14f, param3: "Hello", param4: true);
    }

    public void LookToAnotherObject(Transform main, Transform aim)
    {
        if (Input.GetKey(KeyCode.R))
        {
            Vector3 direction = aim.position - main.position;
            // _f look to _s
            main.rotation = Quaternion.LookRotation(direction, Vector3.up)
                            * Quaternion.Euler(90f, 0f, 0f);
            
            // draw ray
            Debug.DrawLine(main.position, main.position + main.up * 100, Color.yellow);
            Debug.DrawLine(main.position, main.position + main.forward * 100, Color.red);
        }
    }

    /*public void SlerpMethod(Transform main, Transform)
    {
        
    }*/
}
