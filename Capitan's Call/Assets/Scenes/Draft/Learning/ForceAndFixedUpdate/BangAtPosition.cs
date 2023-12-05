using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangAtPosition : MonoBehaviour
{

    public Rigidbody targetRigidbody;
    public float forceValue = 500f;

    public ParticleSystem particleSystem;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            targetRigidbody.AddForceAtPosition(transform.up * forceValue, transform.position);
            particleSystem.Play();
        }
    }
}
