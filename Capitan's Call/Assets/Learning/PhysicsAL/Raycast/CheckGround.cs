using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public float distance;
    public LayerMask layerMask;
    private void Update()
    {
        RaycastHit[] raycastHits;
        raycastHits = Physics.RaycastAll(transform.position, Vector3.up, 100.0f);
        
        Ray ray = new Ray(transform.position, -Vector3.up);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        if (Physics.Raycast(ray, distance, layerMask))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.gray;
        }
    }
}
