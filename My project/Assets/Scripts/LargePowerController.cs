using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargePowerController : MonoBehaviour
{
    public GameObject powerLarge;
    public float speed = 0.10f;
    public float destroyPowerAt = 110f;

    void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("osu");
        if (collision.gameObject.tag == "LargePower")
        {
            Debug.Log("osu2");
            Destroy(gameObject);
        }
    }

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
