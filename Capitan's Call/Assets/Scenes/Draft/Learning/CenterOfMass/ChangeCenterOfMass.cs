using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCenterOfMass : MonoBehaviour
{

    public Transform centerOfMass;

    private void Awake()
    {
        GetComponent<Rigidbody>().centerOfMass = Vector3.Scale(centerOfMass.localPosition, transform.localScale);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(GetComponent<Rigidbody>().worldCenterOfMass, 0.1f);
    }
}
