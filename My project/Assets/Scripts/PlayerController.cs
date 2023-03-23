using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PlayerController : MonoBehaviour
 {
    public float speed = 0.50f;
    public GameObject bulletPrefab;
     
     void Update()
     {
        float vertical = Input.GetAxisRaw("Vertical") * speed;
        float horizontal = Input.GetAxisRaw("Horizontal") * speed;

        transform.Translate(0, vertical, 0);
        transform.Translate(horizontal, 0 , 0);

        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed = speed / 3;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = 1.00f;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
        }


    }
 }