using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // other
    public PowerController powerController;
    public BulletController bulletController;
    public GameObject bulletPrefab;
    public GameObject bombPrefab;

    public bool canFireBullet = true;
    public bool canFireBomb = true;
    public bool isAlive = true;
    private float cooldownForLeveling = 0.2f;
    private float xRangeNegative = -138;
    private float xRangePositive = 100;
    private float yRange = 100;
   
    // bullet
    [SerializeField] public float bulletDamage = 0.8f;
    public float bulletFireRate = 0.07f;

    // bomb
    public int bombFireRate = 5;
    public float bombDamage = 250f;

    // player
    public int playerHp = 3;
    public int bomb = 5;
    public float basePlayerSpeed = 0.30f;
    public float playerSpeed;
    public GameObject healthPrefab;
    public GameObject bombsPrefab;
    private List<GameObject> health;
    private List<GameObject> bombs;
    public float power = 0;
    public int level = 0;
    public int powerForLevelUp = 13; // The amount of power needed for the first level up
    private int powerPerLevel;
    public float levelMax = 8;
    public float bonusDamagePerLevel; // The amount of damage gained from levels
    public bool isMaxLevel = false;

    void Start()
    {
        powerPerLevel = powerForLevelUp;
        bulletController = GetComponent<BulletController>();
        powerController = GetComponent<PowerController>();

        playerSpeed = basePlayerSpeed;

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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Player collides with enemy
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
            GameObject fff = GameObject.Find("PowerController");
            powerController = fff.GetComponent<PowerController>();

            power += powerController.smallPowerAmount;

            var smallPowerBox = GameObject.FindWithTag("SmallPower");
            Destroy(smallPowerBox);
        }

        else if (collision.gameObject.tag == "LargePower")
        {
            GameObject fff = GameObject.Find("PowerController");
            powerController = fff.GetComponent<PowerController>();

            power += powerController.largePowerAmount;

            var largePowerBox = GameObject.FindWithTag("LargePower");
            Destroy(largePowerBox);
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
                playerSpeed = basePlayerSpeed;
            }

            // Shooting
            if (Input.GetButton("Fire") && canFireBullet)
            {
                Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
                canFireBullet = false;
                StartCoroutine(WaitForFire());
            }

            // Bomb
            if (Input.GetButton("Bomb") && bomb != 0)
            {
                if (bomb != 0 && canFireBomb)
                {
                    GameObject bombObject = Instantiate(bombPrefab, transform.position, bombPrefab.transform.rotation);
                    bomb--;
                    canFireBomb = false;
                    StartCoroutine(WaitForBomb());

                    // Removes a bomb from player UI when player uses a bomb
                    int y = bombs.Count - 1;
                    Destroy(bombs[y]);
                    bombs.RemoveAt(y);
                }
            }

            // Leveling
            PlayerLevel();
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

    // Player leveling system
    private void PlayerLevel()
    {
        if (power >= powerForLevelUp && isMaxLevel == false)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                level++;
                bulletDamage += bonusDamagePerLevel;
                power -= powerForLevelUp;
                powerForLevelUp += level + powerPerLevel;
            }

            if (level >= levelMax)
            {
                isMaxLevel = true;
                level = 8;

                // add crazy projectiles for bullet here
            }

            else if (level == 4)
            {
                // add projectile stuff here
            }
        }
    }

    private IEnumerator WaitForFire()
    {
        yield return new WaitForSeconds(bulletFireRate);
        canFireBullet = true;
    }

    public IEnumerator WaitForBomb()
    {
        bulletController = GetComponent<BulletController>();
        yield return new WaitForSeconds(bombFireRate);
        canFireBomb = true;
    }
}