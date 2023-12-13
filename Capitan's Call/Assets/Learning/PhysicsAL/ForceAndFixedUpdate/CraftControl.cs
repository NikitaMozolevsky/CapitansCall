using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftControl : MonoBehaviour
{

    private Rigidbody _rigidbody;
    public float _speed = 5f;
    public float _rotationSpeed = 1f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        // Изменение максимальной скорости вращения (ограничение редактора)
        _rigidbody.maxAngularVelocity = 500;
    }

    private void FixedUpdate()
    {
        float sideForce = Input.GetAxis("Horizontal") * _rotationSpeed;
        float forwardForce = Input.GetAxis("Vertical") * _speed;
        
        _rigidbody.AddRelativeForce(0f, 0f, forwardForce);
        _rigidbody.AddRelativeTorque(0f, sideForce, 0f);
    }
}
