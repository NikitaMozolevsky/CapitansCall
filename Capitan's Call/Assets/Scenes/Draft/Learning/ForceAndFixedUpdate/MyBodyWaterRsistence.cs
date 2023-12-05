using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBodyWater : MonoBehaviour
{
    public Transform ocean;
    private Rigidbody cubeRigidbody;

    public float resistancePower = 10f;

    private void Start()
    {
        cubeRigidbody = transform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y < ocean.position.y - 2)
        {
            cubeRigidbody.AddForce(Vector3.up * resistancePower);
        }
    }
}
