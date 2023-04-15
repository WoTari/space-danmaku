using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    // other
    public PowerController powerController;
    public BulletController bulletController;
    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    private Animator anim;


    public bool canFireBullet = true;
    public bool canFireBomb = true;
    public bool isAlive = true;
    private float xRangeNegative = -138;
    private float xRangePositive = 100;
    private float yRange = 100;

    // bullet
    public float bulletDamage = 0.8f;
    public float bulletFireRate = 0.07f;
    public GameObject playerBullet;
    public GameObject playerBullet2;
    private float n = 1f;
    private float m = 1f;

    // bomb
    public int bombFireRate = 5;
    public float bombDamage = 250f;

    // player
    public int playerHp = 3;
    public int bomb = 5;
    public int graze = 0;
    public int grazeMax = 999;
    public int grazeAmount = 1;
    public float basePlayerSpeed = 0.6f;
    private float playerSpeed;
    public GameObject healthPrefab;
    public GameObject bombsPrefab;
    private List<GameObject> health;
    private List<GameObject> bombs;

    // Player leveling variables
    public float power = 0;
    public float powerMax = 9999;
    public float level = 0;
    public float powerForLevelUp = 13; // The amount of power needed for the first level up
    private float powerPerLevel;
    public float levelMax = 8;
    public float bonusDamagePerLevel; // The amount of damage gained from levels

    void Start()
    {
        powerPerLevel = powerForLevelUp;
        playerSpeed = basePlayerSpeed;
        bulletController = GetComponent<BulletController>();
        powerController = GetComponent<PowerController>();
        anim = GetComponent<Animator>();

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
        if (collision.gameObject.tag == "Enemy" && isAlive)
        {
            int i = health.Count - 1;
            playerHp--;

            // Removes a heart from player UI when player takes a hit
            Destroy(health[i]);
            health.RemoveAt(i);
        }

        // Player collides with enemy bullet
        if (collision.gameObject.tag == "Enemy_Bullet" && graze != grazeMax && isAlive)
        {
            graze += grazeAmount;
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

            // Sets the value of the Direction parameter according to which way the player is moving horizontally
            anim.SetFloat("Direction", horizontal);

            // Slows down the player's movement speed when player presses the given button
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerSpeed = playerSpeed / 4;
            }

            // Returns the movement to normal when player lets go of the given button
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerSpeed = basePlayerSpeed;
            }

            // Shooting
            if (Input.GetButton("Fire") && canFireBullet)
            {
                Shooting();
                canFireBullet = false;
                StartCoroutine(WaitForFire());
            }

            IEnumerator WaitForFire()
            {
                yield return new WaitForSeconds(bulletFireRate);
                canFireBullet = true;
            }

            // Bomb
            if (Input.GetButton("Bomb") && bomb != 0 && canFireBomb)
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

            IEnumerator WaitForBomb()
            {
                yield return new WaitForSeconds(bombFireRate);
                canFireBomb = true;
            }

            // Leveling
            PlayerLevel();
        }

        // Player is dead
        else if (isAlive)
        {
            isAlive = false;
        }
    }

    // Player shooting system
    private void Shooting()
    {
        playerBullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
    }

    // Player leveling system
    void PlayerLevel()
    {
        if (power >= powerForLevelUp && level != levelMax)
        {

            if (level >= levelMax)
            {
                level = levelMax;

                // add crazy projectiles for bullet here
            }

            else if (Input.GetKeyDown(KeyCode.C))
            {
                level++;
                bulletDamage += bonusDamagePerLevel;
                power -= powerForLevelUp;
                powerForLevelUp += level + powerPerLevel;
            }
        }
    }

    void GrazeSystem()
    {
        // graze should increase the amount of score gained from differing sources
    }
}   