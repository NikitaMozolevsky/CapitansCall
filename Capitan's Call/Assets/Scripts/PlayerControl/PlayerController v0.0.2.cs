using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Когда скрипт был на Player
/*[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]*/
public class PlayerControllerV002 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _accelerationRate;
    [SerializeField] private float _decelerationRate;

    
}
