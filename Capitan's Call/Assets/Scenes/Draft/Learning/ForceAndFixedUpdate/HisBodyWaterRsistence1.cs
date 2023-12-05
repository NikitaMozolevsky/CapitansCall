using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HisBodyWater : MonoBehaviour
{
    public Transform ocean;
    private Rigidbody cubeRigidbody;

    public float resistancePower = 10f;

    private void Start()
    {
        cubeRigidbody = transform.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float divePercent = -transform.position.y + transform.localScale.x * 0.5f;
        divePercent = Mathf.Clamp(divePercent, 0f, 1f);
        
        cubeRigidbody.AddForce(Vector3.up * divePercent * resistancePower);
        cubeRigidbody.drag = divePercent * 2f;
        cubeRigidbody.angularDrag = divePercent * 2f;
    }
}
