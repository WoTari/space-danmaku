using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PlayerController : MonoBehaviour
 {
    bool canFire = true;
    public float speed = 0.50f;
    public GameObject bulletPrefab;
    private float xRange = 100;
    private float yRange = 100;
    public float fireRate = 0.07f;

    void Update()
     {
        // Game Border
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        // Movement
        float vertical = Input.GetAxisRaw("Vertical") * speed;
        float horizontal = Input.GetAxisRaw("Horizontal") * speed;

        transform.Translate(0, vertical, 0);
        transform.Translate(horizontal, 0 , 0);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed / 3;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 0.50f;
        }

        // Shooting
        if (Input.GetButton("Fire1") && canFire)
        {
            Fire();
        }

        void Fire()
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
          
            canFire = false;
            StartCoroutine(WaitForFire());
        }

        IEnumerator WaitForFire()
        {
            yield return new WaitForSeconds(fireRate);
            canFire = true;
    }
    }
 }