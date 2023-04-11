using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SmallPowerController : MonoBehaviour
{
    public GameObject powerSmall;
    public float speed = 0.35f;
    public float destroyPowerAt = 110f;

void Update()
    {
        // Moves the power on the y axis
        transform.Translate(Vector2.down * speed);

        // Power gets destroyed when it goes past the boundaries of the game
        if (transform.position.y <= -destroyPowerAt)
        {
            Destroy(gameObject);
        }
    }
}
