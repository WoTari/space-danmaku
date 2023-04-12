using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerLevelText : MonoBehaviour
{
    [SerializeField] TMP_Text playerLevelText;
    private PlayerController playerController;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        // Shows the players current level
        playerLevelText.text = playerController.level.ToString("1f") + " /" + playerController.levelMax;
    }
}
