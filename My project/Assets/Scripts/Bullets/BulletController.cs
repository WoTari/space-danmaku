using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private PlayerController playerController;
    private GameObject enemy;
    public float turnSpeed;

    // bullet
    public float bulletSpeed = 100f;
    public float delayForObjectDestruction;

    // other
    private float yRange = 100;

    // bomb
    public GameObject bombPrefab;

    public float bombDamage = 250f;
    public float bombFireRate = 5f;
    public float bombSpeed = 300f;

    void Start()
    {
        enemy = GameObject.Find("Enemy");
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    public void Bomb()
    {
        StartCoroutine(WaitForBomb());
    }

    public IEnumerator WaitForBomb()
    {
        yield return new WaitForSeconds(bombFireRate);
        playerController.canFireBomb = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && gameObject.tag == "PlayerProjectile")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Bullet movement
        transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed);

        // Bullet gets destroyed when ít goes past the boundaries of the game
        if (transform.position.y >= yRange)
        {
            Destroy(gameObject);
        }
    }
}