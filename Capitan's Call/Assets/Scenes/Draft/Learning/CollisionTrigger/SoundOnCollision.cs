using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollision : MonoBehaviour
{

    public AudioSource audioSource;
    public float volume = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.impulse.magnitude);
        audioSource.volume = collision.impulse.magnitude * volume;
        audioSource.Play();
    }

    private void OnCollisionExit(Collision other)
    {}
    private void OnCollisionStay(Collision collisionInfo)
    {}
}
