using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private PlayerController playerController;

    // bullet
    public float bulletSpeed = 100f;

    // other
    private float yRange = 100;
    private float xRange = 100;

    // bomb
    public GameObject bombPrefab;
<<<<<<< Updated upstream
=======
    public float bombDamage = 250f;
    public float bombFireRate = 5f;
>>>>>>> Stashed changes
    public float bombSpeed = 300f;

    public void Bomb()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
<<<<<<< Updated upstream
        StartCoroutine(playerController.WaitForBomb());
=======
        StartCoroutine(WaitForBomb());
    }

    public IEnumerator WaitForBomb()
    {
        yield return new WaitForSeconds(bombFireRate);
        playerController.canFire = true;
>>>>>>> Stashed changes
    }

    void Update()
    {
        // Bullet movement
        transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed);

        // Bullet gets destroyed when ít goes past the boundaries of the game
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