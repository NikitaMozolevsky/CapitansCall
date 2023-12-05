using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
public class ThirdPersonCameraController : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public bool isClicked = false;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            isClicked = true;
        }
        else
        {
            isClicked = false;
        }
    }
}
