using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class BangAtPosition : MonoBehaviour
{

    public GameObject targetGameObject;
    public Rigidbody targetRigidbody;
    public Transform targetPosition;
    public float forceValue = 1f;

    
    private bool isMoving = false;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            targetRigidbody.AddForceAtPosition(transform.up * forceValue, transform.position);
            MoveToTarget(targetPosition.position, 2);
            Debug.Log("Button pressed!");
        }
    }
    
    private IEnumerator MoveToTarget(Vector3 target, float speed)
    {
        Debug.Log("MoveToTarget Method");
        isMoving = true;

        float elapsedTime = 0f;

        Vector3 startingPos = targetGameObject.transform.position;

        while (elapsedTime < 1f)
        {
            targetGameObject.transform.position = Vector3.Lerp(startingPos, target, elapsedTime);
            elapsedTime += Time.deltaTime * speed;

            yield return null;
        }

        // Гарантируем, что объект точно достигнет целевой точки
        targetGameObject.transform.position = target;

        isMoving = false;
    }
}
