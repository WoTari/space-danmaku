using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    public PowerController powerController;
    public BulletController bulletController;

    // player
    public int playerHp = 3;
    public int bomb = 5;
    public float bulletFirerate = 0.07f;
    public float playerSpeed = 0.60f;
    public GameObject healthPrefab;
    public GameObject bombsPrefab;
    private List<GameObject> health;
    private List<GameObject> bombs;
    public float power = 0;
    public int level = 0;
   

    void Start()
    {
        BulletController bulletController = GetComponent<BulletController>();

        // Player Health
        health = new List<GameObject>();
        GameObject healthUI = GameObject.Find("PlayerHp");

        for (int i = 0; i < playerHp; i++)
        {
            health.Add(Instantiate(healthPrefab, healthUI.transform.position + i * new Vector3(10, 0, 0), healthPrefab.transform.rotation));
        }

        // Player Bombs
        bombs = new List<GameObject>();
        GameObject bombsUI = GameObject.Find("PlayerBombs");
        
        for (int u = 0; u < bomb; u++)
        {
            bombs.Add(Instantiate(bombsPrefab, bombsUI.transform.position + u * new Vector3(10, 0, 0), bombsPrefab.transform.rotation));
        }

        PowerController powerController = GetComponent<PowerController>();
    }

    // Player collides with enemy
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            int i = health.Count - 1;
            playerHp--;

            // Removes a heart from player UI when player takes a hit
            Destroy(health[i]);
            health.RemoveAt(i);
        }

        // If Player collects a power box, gives power to the player
        else if (collision.gameObject.tag == "SmallPower")
        {
            power += powerController.smallPowerAmount;
        }

        else if (collision.gameObject.tag == "LargePower")
        {
            power += powerController.largePowerAmount;
        }
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

                    // Removes a bomb from player UI when player uses a bomb
                    int y = bombs.Count - 1;
                    Destroy(bombs[y]);
                    bombs.RemoveAt(y);
                }
            }
        }

        // Player is dead
        else
        {
            if (isAlive)
            {
                Debug.Log("game over idiot");
                isAlive = false;
            }
        }
    }
}