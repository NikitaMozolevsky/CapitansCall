using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { // Прыжок одном нажатием
            /*_rigidbody.AddForce(0f, 300f, 0f);
            _rigidbody.AddForce(Vector3.up * 300); // Другой способ
            _rigidbody.AddForce(Vector3.up * 300, ForceMode.Force); 
            _rigidbody.AddForce(Vector3.up * 300, ForceMode.Acceleration);*/
            _rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
            /*_rigidbody.AddForce(Vector3.up * 300, ForceMode.VelocityChange);*/
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.K))
        {
            _rigidbody.AddForce(-15f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.L))
        { // Постоянное давление силы
            _rigidbody.AddForce(15f, 0f, 0f);
        }

        
    }
}
