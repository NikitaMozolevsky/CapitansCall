using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMove : MonoBehaviour
{

     public GameObject target;
     public GameObject moveCube;
     public float desiredDuration = 3f;
     public AnimationCurve curve;
     
     private float elapsedTime;
     private Vector3 startPositionVector;
     private Vector3 targetPositionVector;

     private void Start()
     {
          targetPositionVector = target.transform.position;
     }

     private void Update()
     {
          if (Input.GetKeyDown(KeyCode.Space))
          {
               Debug.Log("Space pressed!");
               elapsedTime += Time.deltaTime;
               float precentageComplete = elapsedTime / desiredDuration;
               
               // Стандарт
               /*moveCube.transform.position = Vector3.Slerp
                    (startPositionVector, targetPositionVector, precentageComplete);*/

               // С использование кривой
               moveCube.transform.position = Vector3.Slerp
                    (startPositionVector, targetPositionVector, 
                         curve.Evaluate(precentageComplete));

               // Постепенное замедление
               /*moveCube.transform.position = Vector3.Slerp
                    (startPositionVector, targetPositionVector,
                         Mathf.SmoothStep(0, 1, precentageComplete));*/
               
          }
     }
}
