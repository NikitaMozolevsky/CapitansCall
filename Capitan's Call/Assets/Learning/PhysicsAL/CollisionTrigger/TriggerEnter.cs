using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
    }

    private void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.AddForce(Vector3.up * 20f);
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
    }
}
