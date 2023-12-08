using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public Rigidbody _shipRigidbody;
    private static SpeedController _instance; // Singleton instance
    public static SpeedController Instance => _instance; // Property to access the instance
    public float _shipSpeed;
    public float _shipCurrentSpeed;
    public float _shipAcceleration;
    public float _shipCurrentAcceleration;

    // Singleton initialization
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
    
    public enum SpeedLevel
    {
        ANCHOR, FIRST, SECOND, THIRD
    }

    private void Update()
    {
        AccelerateShip();
    }

    public void SetSpeedLevel(SpeedLevel speedLevel)
    {
        switch (speedLevel)
        {
            case SpeedLevel.ANCHOR:
                _shipSpeed = 0f;
                _shipAcceleration = 0f;
                break;
            case SpeedLevel.FIRST:
                _shipSpeed = 10f;
                _shipAcceleration = 20f;
                break;
            case SpeedLevel.SECOND:
                _shipSpeed = 15f;
                _shipAcceleration = 30f;
                break;
            case SpeedLevel.THIRD:
                _shipSpeed = 20f;
                _shipAcceleration = 40f;
                break;
            default:
                break;
        }
    }
    
    private void AccelerateShip()
    {
        // Получаем текущую скорость и ускорение Rigidbody
        Vector3 currentVelocity = _shipRigidbody.velocity;

        // Плавно изменяем скорость в зависимости от значения TargetSpeedValue
        currentVelocity.z = Mathf.MoveTowards(currentVelocity.z, _shipSpeed, Time.deltaTime);

        // Плавно изменяем ускорение в зависимости от значения TargetAccelerationValue
        AccelerateTowards(ref currentVelocity.z, _shipAcceleration, Time.deltaTime);

        // Применяем изменения к Rigidbody
        _shipRigidbody.velocity = currentVelocity;
        _shipCurrentSpeed = _shipSpeed;
        _shipCurrentAcceleration = _shipAcceleration;
    }

    private void AccelerateTowards(ref float current, float target, float deltaTime)
    {
        // Плавное изменение значения current к target
        current = Mathf.MoveTowards(current, target, deltaTime * 1000);
    }
}
