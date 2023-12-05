using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isActive = true;
    private void OnCollisionEnter(Collision collision)
    {
        /*if (!isActive) return;
        isActive = false;*/
        GetComponent<Rigidbody>().useGravity = true;
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.GetComponent<Enemy>())
        {
            /*collision.gameObject.GetComponent<Enemy>().OnHit();*/
            if (collision.collider.gameObject.GetComponent<EnemyHead>())
            {
                Debug.Log("Head shot!");
            }
        }
    }
}
