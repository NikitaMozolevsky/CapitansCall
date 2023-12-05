using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float bulletVelocity = 20f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletVelocity;
        }
    }
}
