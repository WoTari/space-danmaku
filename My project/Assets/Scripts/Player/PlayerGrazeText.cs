using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGrazeText : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] TMP_Text playerGrazeText;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        playerGrazeText.text = playerController.graze.ToString();
    }
}
