using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 100f;
    private float xRange = 100;
    private float yRange = 100;

    void Update()
    {
        // Bullet movement
        transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed);

        // Bullet gets destroyed when colliding with the boundaries of the game
        if (transform.position.y >= yRange)
        {
            Destroy(gameObject);

            if (transform.position.x >= xRange)
            {
                Destroy(gameObject);
            }
        }

    }
}