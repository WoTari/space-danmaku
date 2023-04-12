using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelUpText : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject levelUpText;
    public bool isVisible = true;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        levelUpText.SetActive(false);
    }

    void Update()
    {
        // Shows the level up text when player can level up
        if (playerController.power == playerController.powerForLevelUp && isVisible)
        {
            levelUpText.SetActive(true);
            isVisible = false;
        }
    }
}
