using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GizmozDebugClasses : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Line shoul be drowed!");
            Debug.DrawLine(Vector3.zero, new Vector3(5, 3, 0), Color.green, 2.5f);
            Debug.Break();
        }
        Debug.DrawRay(new Vector3(10, 10, 10), new Vector3(10, 10, 10), Color.blue);
        Debug.DrawRay(Vector3.zero, Vector3.up * 3, Color.red);
        Debug.DrawRay(transform.position, Vector3.up * 3, Color.cyan);
        Debug.DrawRay(transform.position, transform.up, Color.yellow);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Vector3.zero, 4f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Vector3.zero, 2f);
        Gizmos.DrawWireSphere(Vector3.zero, 3f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Vector3.zero, 5f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(Vector3.zero, Vector3.left * 10);
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(Vector3.zero, Vector3.right * 10);
        Gizmos.DrawSphere(Vector3.zero, 0.1f);
        Gizmos.DrawCube(Vector3.up * 3, new Vector3(1, 4, 4));
    }
}
