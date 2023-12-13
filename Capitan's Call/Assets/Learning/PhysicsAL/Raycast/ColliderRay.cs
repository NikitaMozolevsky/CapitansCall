using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRay : MonoBehaviour
{

    private void Update()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (GetComponent<Collider>().Raycast(cameraRay, out hit, 100f))
        {
            transform.localScale = Vector3.one * 1.2f;
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Renderer>().material.color = Color.white * 0.62f;
            }
        }
        else
        {
            transform.localScale = Vector3.one * 1f;
        }
    }
}
