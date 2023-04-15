using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStarMovement : MonoBehaviour
{
    private ShootingStarController shootingStarController;
    void Start()
    {
        GameObject star = GameObject.Find("Shooting Star Controller");
        shootingStarController = star.GetComponent<ShootingStarController>();
    }

    void Update()
    {
        // Shooting star movement
        transform.Translate(new Vector2(Random.Range(0.4f, 0.7f), Random.Range(-0.2f, -0.5f))
            * shootingStarController.shootingStarSpeed);

        // Shooting star gets destroyed when it goes past the boundaries of the game
        if (transform.position.x >= shootingStarController.getDestroyedAtX)
        {
            Destroy(gameObject);
        }
    }
}
