using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SmallPowerController : MonoBehaviour
{
    public GameObject powerSmall;
    public float speed = 0.35f;
    private float destroyPowerAt = 110f;
    private PlayerController playerController;
    private PowerController powerController;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        GameObject power = GameObject.Find("PowerController");
        powerController = power.GetComponent<PowerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // If player's power is not the maximun amount, add to the player's power count
            if (playerController.power != playerController.powerMax)
            {
                playerController.power += powerController.smallPowerAmount;
            }

            Destroy(gameObject);
        }
    }

    void Update()
    {

        // Moves the power on the x and y axis
        transform.Translate(new Vector2(Time.deltaTime * powerController.smallPowerXPosition, Time.deltaTime * -speed));

        // Power gets destroyed when it goes past the boundaries of the game
        if (transform.position.y <= -destroyPowerAt)
        {
            Destroy(gameObject);
        }
    }
}