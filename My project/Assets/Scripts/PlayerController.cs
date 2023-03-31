using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

 public class PlayerController : MonoBehaviour
 {
    // other
    public bool canFire = true;
    public bool isAlive = true;
    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    private float xRangeNegative = -138;
    private float xRangePositive = 100;
    private float yRange = 100;

    // player
    public int playerHp = 3;
    public int bomb = 5;
    public float bulletFirerate = 0.07f;
    public float playerSpeed = 0.60f;

    // Player loses hp when hit by enemy
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerHp--;
        }
    }

    private void Start()
    {
        BulletController bulletController = GetComponent<BulletController>();
    }

    void Update()
    {
        // Game Border
        if (transform.position.x < xRangeNegative)
        {
            transform.position = new Vector3(xRangeNegative, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRangePositive)
        {
            transform.position = new Vector3(xRangePositive, transform.position.y, transform.position.z);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        // Player is not dead
        if (playerHp != 0)
        {
            // Movement
            float vertical = Input.GetAxisRaw("Vertical") * playerSpeed;
            float horizontal = Input.GetAxisRaw("Horizontal") * playerSpeed;

            transform.Translate(0, vertical, 0);
            transform.Translate(horizontal, 0, 0);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerSpeed = playerSpeed / 3;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerSpeed = 0.50f;
            }

            // Shooting
            if (Input.GetButton("Fire") && canFire)
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
                yield return new WaitForSeconds(bulletFirerate);
                canFire = true;
            }

        // Bomb
        if (Input.GetButton("Bomb") && bomb != 0)
            {
                if (bomb != 0 && canFire)
                {
                    GameObject bombObject = Instantiate(bombPrefab, transform.position, bombPrefab.transform.rotation);
                    BulletController bombController = bombObject.GetComponent<BulletController>();
                    bombController.Bomb();
                    bomb--;
                    canFire = false;
                    StartCoroutine(bombController.WaitForBomb());
                }
            }
        }

        // Player is dead
        else
        {
            Debug.Log("game over idiot");
            isAlive = false;
        } 
    }
}
