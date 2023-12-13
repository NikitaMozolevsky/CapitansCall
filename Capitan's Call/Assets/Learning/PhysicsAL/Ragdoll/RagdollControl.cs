using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour
{

    public Animator animator;
    public Rigidbody[] allRigitbodies;

    private void Awake()
    {
        for (int i = 0; i < allRigitbodies.Length; i++)
        {
            allRigitbodies[i].isKinematic = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MakePhysical();
        }
    }

    private void MakePhysical()
    {
        animator.enabled = false;
        for (int i = 0; i < allRigitbodies.Length; i++)
        {
            allRigitbodies[i].isKinematic = false;
        }
    }
}
